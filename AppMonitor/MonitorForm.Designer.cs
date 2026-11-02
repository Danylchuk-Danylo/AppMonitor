namespace AppMonitor
{
    partial class MonitorForm
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
            components = new System.ComponentModel.Container();
            listBoxActive = new ListBox();
            listBoxForbidden = new ListBox();
            txtForbiddenName = new TextBox();
            txtProcessPath = new TextBox();
            btnAddForbidden = new Button();
            btnOpenLog = new Button();
            btnStartProcess = new Button();
            btnKillSelected = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // listBoxActive
            // 
            listBoxActive.FormattingEnabled = true;
            listBoxActive.Location = new Point(24, 26);
            listBoxActive.Name = "listBoxActive";
            listBoxActive.Size = new Size(240, 164);
            listBoxActive.TabIndex = 0;
            // 
            // listBoxForbidden
            // 
            listBoxForbidden.FormattingEnabled = true;
            listBoxForbidden.Location = new Point(538, 26);
            listBoxForbidden.Name = "listBoxForbidden";
            listBoxForbidden.Size = new Size(240, 164);
            listBoxForbidden.TabIndex = 1;
            // 
            // txtForbiddenName
            // 
            txtForbiddenName.Location = new Point(24, 226);
            txtForbiddenName.Name = "txtForbiddenName";
            txtForbiddenName.Size = new Size(200, 39);
            txtForbiddenName.TabIndex = 2;
            // 
            // txtProcessPath
            // 
            txtProcessPath.Location = new Point(538, 226);
            txtProcessPath.Name = "txtProcessPath";
            txtProcessPath.Size = new Size(200, 39);
            txtProcessPath.TabIndex = 3;
            // 
            // btnAddForbidden
            // 
            btnAddForbidden.Location = new Point(24, 295);
            btnAddForbidden.Name = "btnAddForbidden";
            btnAddForbidden.Size = new Size(150, 46);
            btnAddForbidden.TabIndex = 4;
            btnAddForbidden.Text = "Add";
            btnAddForbidden.UseVisualStyleBackColor = true;
            btnAddForbidden.Click += btnAddForbidden_Click;
            // 
            // btnOpenLog
            // 
            btnOpenLog.Location = new Point(24, 369);
            btnOpenLog.Name = "btnOpenLog";
            btnOpenLog.Size = new Size(150, 46);
            btnOpenLog.TabIndex = 5;
            btnOpenLog.Text = "Open Log";
            btnOpenLog.UseVisualStyleBackColor = true;
            btnOpenLog.Click += btnOpenLog_Click;
            // 
            // btnStartProcess
            // 
            btnStartProcess.Location = new Point(538, 295);
            btnStartProcess.Name = "btnStartProcess";
            btnStartProcess.Size = new Size(150, 46);
            btnStartProcess.TabIndex = 6;
            btnStartProcess.Text = "Start";
            btnStartProcess.UseVisualStyleBackColor = true;
            btnStartProcess.Click += btnStartProcess_Click;
            // 
            // btnKillSelected
            // 
            btnKillSelected.Location = new Point(538, 369);
            btnKillSelected.Name = "btnKillSelected";
            btnKillSelected.Size = new Size(150, 46);
            btnKillSelected.TabIndex = 7;
            btnKillSelected.Text = "Kill";
            btnKillSelected.UseVisualStyleBackColor = true;
            btnKillSelected.Click += btnKillSelected_Click;
            // 
            // MonitorForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnKillSelected);
            Controls.Add(btnStartProcess);
            Controls.Add(btnOpenLog);
            Controls.Add(btnAddForbidden);
            Controls.Add(txtProcessPath);
            Controls.Add(txtForbiddenName);
            Controls.Add(listBoxForbidden);
            Controls.Add(listBoxActive);
            Name = "MonitorForm";
            Text = "MonitorForm";
            Load += MonitorForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox listBoxActive;
        private ListBox listBoxForbidden;
        private TextBox txtForbiddenName;
        private TextBox txtProcessPath;
        private Button btnAddForbidden;
        private Button btnOpenLog;
        private Button btnStartProcess;
        private Button btnKillSelected;
        private System.Windows.Forms.Timer timer1;
    }
}