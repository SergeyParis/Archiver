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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnArchiving = new System.Windows.Forms.Button();
            this.btnChangeFilePath = new System.Windows.Forms.Button();
            this.btnChangeArchivePath = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txbxResultPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbxArhivePath = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblStatusWork = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(203, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Show tree";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(103, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Show info bytes";
            this.button1.UseVisualStyleBackColor = true;
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
            this.txbxResultPath.Text = "path";
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
            this.txbxArhivePath.Text = "path";
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
            // Unarchiving
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 111);
            this.Controls.Add(this.lblStatusWork);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnChangeFilePath);
            this.Controls.Add(this.btnChangeArchivePath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbxResultPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbxArhivePath);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnArchiving);
            this.Name = "Unarchiving";
            this.Text = "Unarchiving";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Unarchiving_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnArchiving;
        private System.Windows.Forms.Button btnChangeFilePath;
        private System.Windows.Forms.Button btnChangeArchivePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbxResultPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbxArhivePath;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblStatusWork;
    }
}