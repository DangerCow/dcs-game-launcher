namespace dcs_game_launcher_prototype_1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.gamesList = new System.Windows.Forms.CheckedListBox();
            this.play_btn = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // gamesList
            // 
            this.gamesList.CheckOnClick = true;
            this.gamesList.Font = new System.Drawing.Font("Yu Gothic", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gamesList.FormattingEnabled = true;
            this.gamesList.HorizontalScrollbar = true;
            this.gamesList.Location = new System.Drawing.Point(12, 12);
            this.gamesList.Name = "gamesList";
            this.gamesList.Size = new System.Drawing.Size(284, 400);
            this.gamesList.TabIndex = 0;
            this.gamesList.UseCompatibleTextRendering = true;
            this.gamesList.SelectedValueChanged += new System.EventHandler(this.gamesList_SelectedValueChanged);
            // 
            // play_btn
            // 
            this.play_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 64F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.play_btn.Location = new System.Drawing.Point(12, 418);
            this.play_btn.Name = "play_btn";
            this.play_btn.Size = new System.Drawing.Size(284, 126);
            this.play_btn.TabIndex = 1;
            this.play_btn.Text = "play";
            this.play_btn.UseVisualStyleBackColor = true;
            this.play_btn.Click += new System.EventHandler(this.play_btn_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.4F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(302, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.listBox1.Size = new System.Drawing.Size(599, 516);
            this.listBox1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 556);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.play_btn);
            this.Controls.Add(this.gamesList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "dcs game launcher 1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox gamesList;
        private System.Windows.Forms.Button play_btn;
        private System.Windows.Forms.ListBox listBox1;
    }
}

