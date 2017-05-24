namespace Lab_2.Forms
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
            this.txbxFilePath = new System.Windows.Forms.TextBox();
            this.btnArchiving = new System.Windows.Forms.Button();
            this.btnShowInfoBytes = new System.Windows.Forms.Button();
            this.ShowInfoTree = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbxArchivePath = new System.Windows.Forms.TextBox();
            this.btnChangeArchivePath = new System.Windows.Forms.Button();
            this.btnChangeFilePath = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatusWork = new System.Windows.Forms.Label();
            this.txbxArchiveName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            // btnShowInfoBytes
            // 
            this.btnShowInfoBytes.Location = new System.Drawing.Point(104, 59);
            this.btnShowInfoBytes.Name = "btnShowInfoBytes";
            this.btnShowInfoBytes.Size = new System.Drawing.Size(94, 23);
            this.btnShowInfoBytes.TabIndex = 3;
            this.btnShowInfoBytes.Text = "Show info bytes";
            this.btnShowInfoBytes.UseVisualStyleBackColor = true;
            // 
            // ShowInfoTree
            // 
            this.ShowInfoTree.Location = new System.Drawing.Point(204, 59);
            this.ShowInfoTree.Name = "ShowInfoTree";
            this.ShowInfoTree.Size = new System.Drawing.Size(94, 23);
            this.ShowInfoTree.TabIndex = 4;
            this.ShowInfoTree.Text = "Show tree";
            this.ShowInfoTree.UseVisualStyleBackColor = true;
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
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(5, 86);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(581, 20);
            this.progressBar1.TabIndex = 10;
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
            // Archiving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 111);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbxArchiveName);
            this.Controls.Add(this.lblStatusWork);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnChangeFilePath);
            this.Controls.Add(this.btnChangeArchivePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbxArchivePath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowInfoTree);
            this.Controls.Add(this.btnShowInfoBytes);
            this.Controls.Add(this.btnArchiving);
            this.Controls.Add(this.txbxFilePath);
            this.Name = "Archiving";
            this.Text = "Archiving";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Archiving_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txbxFilePath;
        private System.Windows.Forms.Button btnArchiving;
        private System.Windows.Forms.Button btnShowInfoBytes;
        private System.Windows.Forms.Button ShowInfoTree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbxArchivePath;
        private System.Windows.Forms.Button btnChangeArchivePath;
        private System.Windows.Forms.Button btnChangeFilePath;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblStatusWork;
        private System.Windows.Forms.TextBox txbxArchiveName;
        private System.Windows.Forms.Label label3;
    }
}