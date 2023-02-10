namespace MP3Win
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Play = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.checkSong = new System.Windows.Forms.CheckedListBox();
            this.textDebug = new System.Windows.Forms.TextBox();
            this.textSongList = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAddSong = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Play
            // 
            this.Play.Location = new System.Drawing.Point(57, 344);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(187, 51);
            this.Play.TabIndex = 0;
            this.Play.Text = "Play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // Stop
            // 
            this.Stop.Location = new System.Drawing.Point(57, 401);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(187, 46);
            this.Stop.TabIndex = 1;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(57, 453);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(187, 46);
            this.Reset.TabIndex = 2;
            this.Reset.Text = "Reset";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
            // 
            // checkSong
            // 
            this.checkSong.CheckOnClick = true;
            this.checkSong.FormattingEnabled = true;
            this.checkSong.Items.AddRange(new object[] {
            "Balld",
            "Rap",
            "New"});
            this.checkSong.Location = new System.Drawing.Point(12, 12);
            this.checkSong.Name = "checkSong";
            this.checkSong.Size = new System.Drawing.Size(140, 58);
            this.checkSong.TabIndex = 3;
            this.checkSong.SelectedIndexChanged += new System.EventHandler(this.CheckSong_SelectedIndexChanged);
            // 
            // textDebug
            // 
            this.textDebug.Location = new System.Drawing.Point(12, 258);
            this.textDebug.Multiline = true;
            this.textDebug.Name = "textDebug";
            this.textDebug.Size = new System.Drawing.Size(280, 80);
            this.textDebug.TabIndex = 5;
            // 
            // textSongList
            // 
            this.textSongList.Location = new System.Drawing.Point(12, 76);
            this.textSongList.Multiline = true;
            this.textSongList.Name = "textSongList";
            this.textSongList.Size = new System.Drawing.Size(280, 176);
            this.textSongList.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(158, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(134, 29);
            this.textBox1.TabIndex = 7;
            // 
            // btnAddSong
            // 
            this.btnAddSong.Location = new System.Drawing.Point(158, 47);
            this.btnAddSong.Name = "btnAddSong";
            this.btnAddSong.Size = new System.Drawing.Size(134, 23);
            this.btnAddSong.TabIndex = 8;
            this.btnAddSong.Text = "노래추가";
            this.btnAddSong.UseVisualStyleBackColor = true;
            this.btnAddSong.Click += new System.EventHandler(this.btnAddSong_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 519);
            this.Controls.Add(this.btnAddSong);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.textSongList);
            this.Controls.Add(this.textDebug);
            this.Controls.Add(this.checkSong);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Play);
            this.Name = "Form1";
            this.Text = "MP3";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private Button Play;
        private Button Stop;
        private Button Reset;
        private CheckedListBox checkSong;
        private TextBox textDebug;
        private TextBox textSongList;
        private TextBox textBox1;
        private Button btnAddSong;
    }
}