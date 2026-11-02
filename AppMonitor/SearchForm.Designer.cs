namespace AppMonitor
{
    partial class SearchForm
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
            txtWords = new TextBox();
            btnSelectFolder = new Button();
            lblFolder = new Label();
            btnStart = new Button();
            btnPause = new Button();
            btnResume = new Button();
            btnStop = new Button();
            progressBar1 = new ProgressBar();
            SuspendLayout();
            // 
            // txtWords
            // 
            txtWords.Location = new Point(12, 27);
            txtWords.Multiline = true;
            txtWords.Name = "txtWords";
            txtWords.Size = new Size(289, 221);
            txtWords.TabIndex = 0;
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Location = new Point(12, 338);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(289, 46);
            btnSelectFolder.TabIndex = 1;
            btnSelectFolder.Text = "Select Output Folder";
            btnSelectFolder.UseVisualStyleBackColor = true;
            // 
            // lblFolder
            // 
            lblFolder.AutoSize = true;
            lblFolder.Location = new Point(12, 251);
            lblFolder.Name = "lblFolder";
            lblFolder.Size = new Size(219, 32);
            lblFolder.TabIndex = 2;
            lblFolder.Text = "Folder not selected";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(397, 69);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(150, 46);
            btnStart.TabIndex = 3;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            // 
            // btnPause
            // 
            btnPause.Location = new Point(598, 69);
            btnPause.Name = "btnPause";
            btnPause.Size = new Size(150, 46);
            btnPause.TabIndex = 4;
            btnPause.Text = "Pause";
            btnPause.UseVisualStyleBackColor = true;
            // 
            // btnResume
            // 
            btnResume.Location = new Point(598, 171);
            btnResume.Name = "btnResume";
            btnResume.Size = new Size(150, 46);
            btnResume.TabIndex = 5;
            btnResume.Text = "Resume";
            btnResume.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(397, 171);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(150, 46);
            btnStop.TabIndex = 6;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(455, 283);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(293, 118);
            progressBar1.TabIndex = 7;
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(progressBar1);
            Controls.Add(btnStop);
            Controls.Add(btnResume);
            Controls.Add(btnPause);
            Controls.Add(btnStart);
            Controls.Add(lblFolder);
            Controls.Add(btnSelectFolder);
            Controls.Add(txtWords);
            Name = "SearchForm";
            Text = "SearchForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtWords;
        private Button btnSelectFolder;
        private Label lblFolder;
        private Button btnStart;
        private Button btnPause;
        private Button btnResume;
        private Button btnStop;
        private ProgressBar progressBar1;
    }
}