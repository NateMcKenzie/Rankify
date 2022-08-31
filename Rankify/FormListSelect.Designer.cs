namespace SpotifyTourney
{
    partial class FormListSelect
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListSelect));
            this.listBox = new System.Windows.Forms.ListBox();
            this.ProfileTimer = new System.Windows.Forms.Timer(this.components);
            this.labelName = new System.Windows.Forms.Label();
            this.buttonSelect = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox
            // 
            this.listBox.FormattingEnabled = true;
            this.listBox.Location = new System.Drawing.Point(12, 63);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(322, 277);
            this.listBox.TabIndex = 0;
            this.listBox.UseWaitCursor = true;
            this.listBox.SelectedValueChanged += new System.EventHandler(this.ListBox_SelectedValueChanged);
            // 
            // ProfileTimer
            // 
            this.ProfileTimer.Enabled = true;
            this.ProfileTimer.Interval = 500;
            this.ProfileTimer.Tick += new System.EventHandler(this.ProfileTimer_Tick);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(12, 23);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(163, 22);
            this.labelName.TabIndex = 2;
            this.labelName.Tag = 3;
            this.labelName.Text = "Accessing Profile...";
            this.labelName.UseWaitCursor = true;
            // 
            // buttonSelect
            // 
            this.buttonSelect.Enabled = false;
            this.buttonSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelect.Location = new System.Drawing.Point(104, 349);
            this.buttonSelect.Name = "buttonSelect";
            this.buttonSelect.Size = new System.Drawing.Size(139, 45);
            this.buttonSelect.TabIndex = 3;
            this.buttonSelect.Tag = "";
            this.buttonSelect.Text = "Select playlist";
            this.buttonSelect.UseVisualStyleBackColor = true;
            this.buttonSelect.UseWaitCursor = true;
            this.buttonSelect.Click += new System.EventHandler(this.ButtonSelect_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.Enabled = false;
            this.buttonLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoad.Location = new System.Drawing.Point(104, 400);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(139, 45);
            this.buttonLoad.TabIndex = 4;
            this.buttonLoad.Tag = "";
            this.buttonLoad.Text = "Load Rankings";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.UseWaitCursor = true;
            this.buttonLoad.Click += new System.EventHandler(this.ButtonLoad_Click);
            // 
            // FormListSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 461);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.buttonSelect);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.listBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormListSelect";
            this.Text = "Rankify";
            this.UseWaitCursor = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.Timer ProfileTimer;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Button buttonSelect;
        private System.Windows.Forms.Button buttonLoad;
    }
}

