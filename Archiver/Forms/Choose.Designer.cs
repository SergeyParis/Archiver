namespace Lab_2.Forms
{
    partial class Choose
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnArchiving = new System.Windows.Forms.Button();
            this.btnUnarchiving = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnArchiving
            // 
            this.btnArchiving.Location = new System.Drawing.Point(12, 12);
            this.btnArchiving.Name = "btnArchiving";
            this.btnArchiving.Size = new System.Drawing.Size(126, 29);
            this.btnArchiving.TabIndex = 0;
            this.btnArchiving.Text = "archiving";
            this.btnArchiving.UseVisualStyleBackColor = true;
            this.btnArchiving.Click += new System.EventHandler(this.btnArchiving_Click);
            // 
            // btnUnarchiving
            // 
            this.btnUnarchiving.Location = new System.Drawing.Point(144, 12);
            this.btnUnarchiving.Name = "btnUnarchiving";
            this.btnUnarchiving.Size = new System.Drawing.Size(126, 29);
            this.btnUnarchiving.TabIndex = 1;
            this.btnUnarchiving.Text = "unarchiving";
            this.btnUnarchiving.UseVisualStyleBackColor = true;
            this.btnUnarchiving.Click += new System.EventHandler(this.btnUnarchiving_Click);
            // 
            // Choose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 54);
            this.Controls.Add(this.btnUnarchiving);
            this.Controls.Add(this.btnArchiving);
            this.Name = "Choose";
            this.Text = "Choose";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnArchiving;
        private System.Windows.Forms.Button btnUnarchiving;
    }
}

