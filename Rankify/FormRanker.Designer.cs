namespace SpotifyTourney
{
    partial class FormRanker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRanker));
            this.listBoxSongs = new System.Windows.Forms.ListBox();
            this.buttonWinner1 = new System.Windows.Forms.Button();
            this.buttonWinner2 = new System.Windows.Forms.Button();
            this.songDisplay2 = new SpotifyTourney.SongDisplay();
            this.songDisplay1 = new SpotifyTourney.SongDisplay();
            this.buttonPlay1 = new System.Windows.Forms.Button();
            this.buttonPlay2 = new System.Windows.Forms.Button();
            this.buttonExport = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxSongs
            // 
            this.listBoxSongs.FormattingEnabled = true;
            this.listBoxSongs.Location = new System.Drawing.Point(322, 36);
            this.listBoxSongs.Name = "listBoxSongs";
            this.listBoxSongs.Size = new System.Drawing.Size(157, 225);
            this.listBoxSongs.TabIndex = 0;
            // 
            // buttonWinner1
            // 
            this.buttonWinner1.Location = new System.Drawing.Point(74, 318);
            this.buttonWinner1.Name = "buttonWinner1";
            this.buttonWinner1.Size = new System.Drawing.Size(157, 54);
            this.buttonWinner1.TabIndex = 3;
            this.buttonWinner1.Tag = "1";
            this.buttonWinner1.Text = "Winner";
            this.buttonWinner1.UseVisualStyleBackColor = true;
            this.buttonWinner1.Click += new System.EventHandler(this.ButtonWinner1_Click);
            // 
            // buttonWinner2
            // 
            this.buttonWinner2.Location = new System.Drawing.Point(577, 318);
            this.buttonWinner2.Name = "buttonWinner2";
            this.buttonWinner2.Size = new System.Drawing.Size(157, 54);
            this.buttonWinner2.TabIndex = 4;
            this.buttonWinner2.Tag = "2";
            this.buttonWinner2.Text = "Winner";
            this.buttonWinner2.UseVisualStyleBackColor = true;
            this.buttonWinner2.Click += new System.EventHandler(this.ButtonWinner2_Click);
            // 
            // songDisplay2
            // 
            this.songDisplay2.Location = new System.Drawing.Point(485, 12);
            this.songDisplay2.Name = "songDisplay2";
            this.songDisplay2.Size = new System.Drawing.Size(300, 300);
            this.songDisplay2.TabIndex = 2;
            // 
            // songDisplay1
            // 
            this.songDisplay1.Location = new System.Drawing.Point(12, 12);
            this.songDisplay1.Name = "songDisplay1";
            this.songDisplay1.Size = new System.Drawing.Size(300, 300);
            this.songDisplay1.TabIndex = 1;
            // 
            // buttonPlay1
            // 
            this.buttonPlay1.Location = new System.Drawing.Point(74, 378);
            this.buttonPlay1.Name = "buttonPlay1";
            this.buttonPlay1.Size = new System.Drawing.Size(157, 54);
            this.buttonPlay1.TabIndex = 5;
            this.buttonPlay1.Tag = "1";
            this.buttonPlay1.Text = "Play";
            this.buttonPlay1.UseVisualStyleBackColor = true;
            this.buttonPlay1.Click += new System.EventHandler(this.ButtonPlay1_Click);
            // 
            // buttonPlay2
            // 
            this.buttonPlay2.Location = new System.Drawing.Point(577, 378);
            this.buttonPlay2.Name = "buttonPlay2";
            this.buttonPlay2.Size = new System.Drawing.Size(157, 54);
            this.buttonPlay2.TabIndex = 6;
            this.buttonPlay2.Tag = "1";
            this.buttonPlay2.Text = "Play";
            this.buttonPlay2.UseVisualStyleBackColor = true;
            this.buttonPlay2.Click += new System.EventHandler(this.ButtonPlay2_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(322, 318);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(157, 54);
            this.buttonExport.TabIndex = 7;
            this.buttonExport.Text = "Export to Spotify";
            this.buttonExport.UseVisualStyleBackColor = true;
            this.buttonExport.Click += new System.EventHandler(this.ButtonExport_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(322, 378);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(157, 54);
            this.buttonSave.TabIndex = 8;
            this.buttonSave.Text = "Save Rankings";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // FormRanker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 451);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonPlay2);
            this.Controls.Add(this.buttonPlay1);
            this.Controls.Add(this.buttonWinner2);
            this.Controls.Add(this.buttonWinner1);
            this.Controls.Add(this.songDisplay2);
            this.Controls.Add(this.songDisplay1);
            this.Controls.Add(this.listBoxSongs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRanker";
            this.Text = "Rankify";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormRanker_FormClosing);
            this.DoubleClick += new System.EventHandler(this.FormRanker_DoubleClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxSongs;
        private SongDisplay songDisplay1;
        private SongDisplay songDisplay2;
        private System.Windows.Forms.Button buttonWinner1;
        private System.Windows.Forms.Button buttonWinner2;
        private System.Windows.Forms.Button buttonPlay1;
        private System.Windows.Forms.Button buttonPlay2;
        private System.Windows.Forms.Button buttonExport;
        private System.Windows.Forms.Button buttonSave;
    }
}