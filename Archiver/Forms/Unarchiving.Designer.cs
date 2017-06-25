namespace Lab_2.Forms
{
    partial class Unarchiving
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
            this.btnArchiving = new System.Windows.Forms.Button();
            this.btnChangeFilePath = new System.Windows.Forms.Button();
            this.btnChangeArchivePath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txbxResultPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbxArhivePath = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatusWork = new System.Windows.Forms.Label();
            this.lblTimerRemaining = new System.Windows.Forms.Label();
            this.lblTimeRemaining = new System.Windows.Forms.Label();
            this.lblTimePassed = new System.Windows.Forms.Label();
            this.lblTimerPassed = new System.Windows.Forms.Label();
            this.timerProgress = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnArchiving
            // 
            this.btnArchiving.Location = new System.Drawing.Point(3, 59);
            this.btnArchiving.Name = "btnArchiving";
            this.btnArchiving.Size = new System.Drawing.Size(94, 23);
            this.btnArchiving.TabIndex = 5;
            this.btnArchiving.Text = "Unarchiving";
            this.btnArchiving.UseVisualStyleBackColor = true;
            this.btnArchiving.Click += new System.EventHandler(this.btnUnarchiving_Click);
            // 
            // btnChangeFilePath
            // 
            this.btnChangeFilePath.Location = new System.Drawing.Point(551, 7);
            this.btnChangeFilePath.Name = "btnChangeFilePath";
            this.btnChangeFilePath.Size = new System.Drawing.Size(34, 22);
            this.btnChangeFilePath.TabIndex = 15;
            this.btnChangeFilePath.Text = "...";
            this.btnChangeFilePath.UseVisualStyleBackColor = true;
            this.btnChangeFilePath.Click += new System.EventHandler(this.btnChangeArchivePath_Click);
            // 
            // btnChangeArchivePath
            // 
            this.btnChangeArchivePath.Location = new System.Drawing.Point(551, 33);
            this.btnChangeArchivePath.Name = "btnChangeArchivePath";
            this.btnChangeArchivePath.Size = new System.Drawing.Size(34, 22);
            this.btnChangeArchivePath.TabIndex = 14;
            this.btnChangeArchivePath.Text = "...";
            this.btnChangeArchivePath.UseVisualStyleBackColor = true;
            this.btnChangeArchivePath.Click += new System.EventHandler(this.btnChangeResultPath_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 13;
            this.label2.Text = "Result path";
            // 
            // txbxResultPath
            // 
            this.txbxResultPath.BackColor = System.Drawing.SystemColors.Info;
            this.txbxResultPath.Location = new System.Drawing.Point(104, 34);
            this.txbxResultPath.Name = "txbxResultPath";
            this.txbxResultPath.ReadOnly = true;
            this.txbxResultPath.Size = new System.Drawing.Size(442, 20);
            this.txbxResultPath.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "Archive path";
            // 
            // txbxArhivePath
            // 
            this.txbxArhivePath.BackColor = System.Drawing.SystemColors.Info;
            this.txbxArhivePath.Location = new System.Drawing.Point(104, 8);
            this.txbxArhivePath.Name = "txbxArhivePath";
            this.txbxArhivePath.ReadOnly = true;
            this.txbxArhivePath.Size = new System.Drawing.Size(442, 20);
            this.txbxArhivePath.TabIndex = 10;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(5, 86);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(581, 20);
            this.progressBar1.TabIndex = 16;
            // 
            // lblStatusWork
            // 
            this.lblStatusWork.AutoSize = true;
            this.lblStatusWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatusWork.Location = new System.Drawing.Point(474, 62);
            this.lblStatusWork.Name = "lblStatusWork";
            this.lblStatusWork.Size = new System.Drawing.Size(0, 15);
            this.lblStatusWork.TabIndex = 19;
            // 
            // lblTimerRemaining
            // 
            this.lblTimerRemaining.AutoSize = true;
            this.lblTimerRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimerRemaining.Location = new System.Drawing.Point(520, 112);
            this.lblTimerRemaining.Name = "lblTimerRemaining";
            this.lblTimerRemaining.Size = new System.Drawing.Size(67, 15);
            this.lblTimerRemaining.TabIndex = 23;
            this.lblTimerRemaining.Text = "- -:- -:- -.- - -";
            // 
            // lblTimeRemaining
            // 
            this.lblTimeRemaining.AutoSize = true;
            this.lblTimeRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimeRemaining.Location = new System.Drawing.Point(418, 112);
            this.lblTimeRemaining.Name = "lblTimeRemaining";
            this.lblTimeRemaining.Size = new System.Drawing.Size(97, 15);
            this.lblTimeRemaining.TabIndex = 22;
            this.lblTimeRemaining.Text = "Time remaining:";
            // 
            // lblTimePassed
            // 
            this.lblTimePassed.AutoSize = true;
            this.lblTimePassed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimePassed.Location = new System.Drawing.Point(3, 112);
            this.lblTimePassed.Name = "lblTimePassed";
            this.lblTimePassed.Size = new System.Drawing.Size(81, 15);
            this.lblTimePassed.TabIndex = 21;
            this.lblTimePassed.Text = "Time passed:";
            // 
            // lblTimerPassed
            // 
            this.lblTimerPassed.AutoSize = true;
            this.lblTimerPassed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimerPassed.Location = new System.Drawing.Point(87, 112);
            this.lblTimerPassed.Name = "lblTimerPassed";
            this.lblTimerPassed.Size = new System.Drawing.Size(67, 15);
            this.lblTimerPassed.TabIndex = 20;
            this.lblTimerPassed.Text = "- -:- -:- -.- - -";
            // 
            // timerProgress
            // 
            this.timerProgress.Interval = 1;
            this.timerProgress.Tick += new System.EventHandler(this.timerProgress_Tick);
            // 
            // Unarchiving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 136);
            this.Controls.Add(this.lblTimerRemaining);
            this.Controls.Add(this.lblTimeRemaining);
            this.Controls.Add(this.lblTimePassed);
            this.Controls.Add(this.lblTimerPassed);
            this.Controls.Add(this.lblStatusWork);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnChangeFilePath);
            this.Controls.Add(this.btnChangeArchivePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbxResultPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbxArhivePath);
            this.Controls.Add(this.btnArchiving);
            this.MaximumSize = new System.Drawing.Size(620, 175);
            this.MinimumSize = new System.Drawing.Size(620, 175);
            this.Name = "Unarchiving";
            this.Text = "Unarchiving";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Unarchiving_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnArchiving;
        private System.Windows.Forms.Button btnChangeFilePath;
        private System.Windows.Forms.Button btnChangeArchivePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbxResultPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbxArhivePath;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblStatusWork;
        private System.Windows.Forms.Label lblTimerRemaining;
        private System.Windows.Forms.Label lblTimeRemaining;
        private System.Windows.Forms.Label lblTimePassed;
        private System.Windows.Forms.Label lblTimerPassed;
        private System.Windows.Forms.Timer timerProgress;
    }
}