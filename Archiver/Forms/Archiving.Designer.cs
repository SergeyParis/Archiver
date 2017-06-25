namespace Archiver.Forms
{
    partial class Archiving
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
            this.txbxFilePath = new System.Windows.Forms.TextBox();
            this.btnArchiving = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbxArchivePath = new System.Windows.Forms.TextBox();
            this.btnChangeArchivePath = new System.Windows.Forms.Button();
            this.btnChangeFilePath = new System.Windows.Forms.Button();
            this.progressBarFileArchiving = new System.Windows.Forms.ProgressBar();
            this.lblStatusWork = new System.Windows.Forms.Label();
            this.txbxArchiveName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timerProgress = new System.Windows.Forms.Timer(this.components);
            this.lblTimerPassed = new System.Windows.Forms.Label();
            this.label02 = new System.Windows.Forms.Label();
            this.label01 = new System.Windows.Forms.Label();
            this.lblTimerRemaining = new System.Windows.Forms.Label();
            this.progressBarInfoArchiving = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // txbxFilePath
            // 
            this.txbxFilePath.BackColor = System.Drawing.SystemColors.Info;
            this.txbxFilePath.Location = new System.Drawing.Point(105, 8);
            this.txbxFilePath.Name = "txbxFilePath";
            this.txbxFilePath.ReadOnly = true;
            this.txbxFilePath.Size = new System.Drawing.Size(442, 20);
            this.txbxFilePath.TabIndex = 1;
            // 
            // btnArchiving
            // 
            this.btnArchiving.Location = new System.Drawing.Point(4, 59);
            this.btnArchiving.Name = "btnArchiving";
            this.btnArchiving.Size = new System.Drawing.Size(94, 23);
            this.btnArchiving.TabIndex = 2;
            this.btnArchiving.Text = "Archiving";
            this.btnArchiving.UseVisualStyleBackColor = true;
            this.btnArchiving.Click += new System.EventHandler(this.btnArchiving_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(22, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "File path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(13, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Archive path";
            // 
            // txbxArchivePath
            // 
            this.txbxArchivePath.BackColor = System.Drawing.SystemColors.Info;
            this.txbxArchivePath.Location = new System.Drawing.Point(105, 34);
            this.txbxArchivePath.Name = "txbxArchivePath";
            this.txbxArchivePath.ReadOnly = true;
            this.txbxArchivePath.Size = new System.Drawing.Size(288, 20);
            this.txbxArchivePath.TabIndex = 6;
            // 
            // btnChangeArchivePath
            // 
            this.btnChangeArchivePath.Location = new System.Drawing.Point(552, 33);
            this.btnChangeArchivePath.Name = "btnChangeArchivePath";
            this.btnChangeArchivePath.Size = new System.Drawing.Size(34, 22);
            this.btnChangeArchivePath.TabIndex = 8;
            this.btnChangeArchivePath.Text = "...";
            this.btnChangeArchivePath.UseVisualStyleBackColor = true;
            this.btnChangeArchivePath.Click += new System.EventHandler(this.btnChangeArchivePath_Click);
            // 
            // btnChangeFilePath
            // 
            this.btnChangeFilePath.Location = new System.Drawing.Point(552, 7);
            this.btnChangeFilePath.Name = "btnChangeFilePath";
            this.btnChangeFilePath.Size = new System.Drawing.Size(34, 22);
            this.btnChangeFilePath.TabIndex = 9;
            this.btnChangeFilePath.Text = "...";
            this.btnChangeFilePath.UseVisualStyleBackColor = true;
            this.btnChangeFilePath.Click += new System.EventHandler(this.btnChangeFilePath_Click);
            // 
            // progressBarFileArchiving
            // 
            this.progressBarFileArchiving.Location = new System.Drawing.Point(104, 86);
            this.progressBarFileArchiving.Name = "progressBarFileArchiving";
            this.progressBarFileArchiving.Size = new System.Drawing.Size(482, 20);
            this.progressBarFileArchiving.TabIndex = 10;
            // 
            // lblStatusWork
            // 
            this.lblStatusWork.AutoSize = true;
            this.lblStatusWork.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatusWork.Location = new System.Drawing.Point(516, 62);
            this.lblStatusWork.Name = "lblStatusWork";
            this.lblStatusWork.Size = new System.Drawing.Size(0, 15);
            this.lblStatusWork.TabIndex = 11;
            // 
            // txbxArchiveName
            // 
            this.txbxArchiveName.Location = new System.Drawing.Point(446, 34);
            this.txbxArchiveName.Name = "txbxArchiveName";
            this.txbxArchiveName.Size = new System.Drawing.Size(100, 20);
            this.txbxArchiveName.TabIndex = 12;
            this.txbxArchiveName.Text = "Archive";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(399, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Name";
            // 
            // timerProgress
            // 
            this.timerProgress.Interval = 1;
            this.timerProgress.Tick += new System.EventHandler(this.timerProgress_Tick);
            // 
            // lblTimerPassed
            // 
            this.lblTimerPassed.AutoSize = true;
            this.lblTimerPassed.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimerPassed.Location = new System.Drawing.Point(88, 113);
            this.lblTimerPassed.Name = "lblTimerPassed";
            this.lblTimerPassed.Size = new System.Drawing.Size(67, 15);
            this.lblTimerPassed.TabIndex = 14;
            this.lblTimerPassed.Text = "- -:- -:- -.- - -";
            // 
            // label02
            // 
            this.label02.AutoSize = true;
            this.label02.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label02.Location = new System.Drawing.Point(4, 113);
            this.label02.Name = "label02";
            this.label02.Size = new System.Drawing.Size(81, 15);
            this.label02.TabIndex = 15;
            this.label02.Text = "Time passed:";
            // 
            // label01
            // 
            this.label01.AutoSize = true;
            this.label01.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label01.Location = new System.Drawing.Point(408, 113);
            this.label01.Name = "label01";
            this.label01.Size = new System.Drawing.Size(97, 15);
            this.label01.TabIndex = 16;
            this.label01.Text = "Time remaining:";
            // 
            // lblTimerRemaining
            // 
            this.lblTimerRemaining.AutoSize = true;
            this.lblTimerRemaining.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTimerRemaining.Location = new System.Drawing.Point(510, 113);
            this.lblTimerRemaining.Name = "lblTimerRemaining";
            this.lblTimerRemaining.Size = new System.Drawing.Size(67, 15);
            this.lblTimerRemaining.TabIndex = 17;
            this.lblTimerRemaining.Text = "- -:- -:- -.- - -";
            // 
            // progressBarInfoArchiving
            // 
            this.progressBarInfoArchiving.Location = new System.Drawing.Point(4, 86);
            this.progressBarInfoArchiving.Name = "progressBarInfoArchiving";
            this.progressBarInfoArchiving.Size = new System.Drawing.Size(94, 20);
            this.progressBarInfoArchiving.TabIndex = 18;
            // 
            // Archiving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 136);
            this.Controls.Add(this.progressBarInfoArchiving);
            this.Controls.Add(this.lblTimerRemaining);
            this.Controls.Add(this.label01);
            this.Controls.Add(this.label02);
            this.Controls.Add(this.lblTimerPassed);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbxArchiveName);
            this.Controls.Add(this.lblStatusWork);
            this.Controls.Add(this.progressBarFileArchiving);
            this.Controls.Add(this.btnChangeFilePath);
            this.Controls.Add(this.btnChangeArchivePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbxArchivePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnArchiving);
            this.Controls.Add(this.txbxFilePath);
            this.MaximumSize = new System.Drawing.Size(620, 175);
            this.MinimumSize = new System.Drawing.Size(620, 175);
            this.Name = "Archiving";
            this.Text = "Archiving";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Archiving_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txbxFilePath;
        private System.Windows.Forms.Button btnArchiving;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbxArchivePath;
        private System.Windows.Forms.Button btnChangeArchivePath;
        private System.Windows.Forms.Button btnChangeFilePath;
        private System.Windows.Forms.ProgressBar progressBarFileArchiving;
        private System.Windows.Forms.Label lblStatusWork;
        private System.Windows.Forms.TextBox txbxArchiveName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerProgress;
        private System.Windows.Forms.Label lblTimerPassed;
        private System.Windows.Forms.Label label02;
        private System.Windows.Forms.Label label01;
        private System.Windows.Forms.Label lblTimerRemaining;
        private System.Windows.Forms.ProgressBar progressBarInfoArchiving;
    }
}