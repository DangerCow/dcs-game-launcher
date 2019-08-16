using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dcs_game_launcher_prototype_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        public Dictionary<string, string> games = new Dictionary<string, string>();

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Console.Title = "dcs game launcher console";
            }
            catch { }
            log("loaded game launcher");

            if (!File.Exists("data.txt") || !Directory.Exists("data"))
            {
                if (!File.Exists("data.txt")) { File.Create("data.txt"); }
                if (!Directory.Exists("data")) { Directory.CreateDirectory("data"); }
                System.Windows.Forms.Application.Restart();
            }


            WebClient client = new WebClient();
            string games_data = client.DownloadString("https://coding-prototype-database.glitch.me/data3.txt");

            foreach (string line in games_data.Split('\n'))
            {
                log("loaded game: " + line);
                string key = line.Split('|')[0];
                string value = line.Split('|')[1];

                gamesList.Items.Add(key);

                games.Add(key, value);
            }
        }

        private void gamesList_SelectedValueChanged(object sender, EventArgs e)
        {
            gamesList.SelectedIndex = -1;
        }

        private void play_btn_Click(object sender, EventArgs e)
        {
            if(gamesList.CheckedItems.Count == 1){
                log("\nstarting: " + gamesList.CheckedItems[0] + "\n");
                start_game(games[gamesList.CheckedItems[0].ToString()], gamesList.CheckedItems[0].ToString());
            }
            else if(gamesList.CheckedItems.Count == 0)
            {
                log("no game selected");
            }
            else
            {
                log("cannot slect more then 1 game");
            }
        }

        private void start_game(string url, string name)
        {
            log("downloading game config: " + url);

            WebClient client = new WebClient();
            string data = client.DownloadString(url);

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(data);
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;

            log("geting varibles from config");
            //get varibles from game data
            string[] lines = data.Split('\n');

            string version = lines[1];
            string zip_link = lines[4];
            string zip_directroy = lines[7];
            string unzip_directroy = lines[10];
            string game_directroy = lines[13];

            bool game_in_data = false;
            int old_ver_line = 0;
            int i = 0;

            string old_ver = "";

            List<string> data_lines = File.ReadAllLines("data.txt").ToList();
            foreach (string line in data_lines)
            {
                if (line.Split('|')[0] == name) { game_in_data = true;  old_ver_line = i; }
                i++;
            }

            if (!game_in_data)
            {
                data_lines.Add(name + "|" + version);
                //download game
                log("downloading game: " + game_directroy);
                data_lines.Add(name + "|" + version);
                download_then_run_game(version, zip_link, zip_directroy, unzip_directroy, game_directroy);
            }
            else
            {
                old_ver = data_lines[old_ver_line].Split('|')[1] ;
                if (old_ver != version)
                {
                    //download game
                    log("downloading update: " + game_directroy);
                    data_lines[old_ver_line] = name + "|" + version;
                    download_then_run_game(version, zip_link, zip_directroy, unzip_directroy, game_directroy);
                }
                else
                {
                    //run game
                    run_game(game_directroy);
                }
            }

            System.IO.File.WriteAllLines("data.txt", data_lines);
        }

        private void download_then_run_game(string version, string zip_link, string zip_directroy, string unzip_directory, string game_directory)
        {
            WebClient client = new WebClient();
            client.DownloadFile(zip_link, zip_directroy);

            try
            {
                var dir = new DirectoryInfo(unzip_directory);
                dir.Attributes = dir.Attributes & ~FileAttributes.ReadOnly;
                dir.Delete(true);
            }
            catch { }

            ZipFile.ExtractToDirectory(zip_directroy, unzip_directory);

            run_game(game_directory);
        }

        private void run_game(string game_directory)
        {
            log("runing game");

            string sub_directroy = string.Join("/", game_directory.Split('/').Take(game_directory.Split('/').Count() - 1));
            string exe_name = game_directory.Split('/')[game_directory.Split('/').Count() - 1];

            System.Diagnostics.Process.Start("CMD.exe", "/K " + "cd " + sub_directroy + "&&" + exe_name);
        }

        private void log(string log)
        {
            Console.WriteLine(log);
            listBox1.Items.Add(log);
        }
    }
}
