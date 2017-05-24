namespace Lab_2.Forms
{
    using Lab_2;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class Choose : Form
    {
        public Choose()
        {
            InitializeComponent();
        }

        private void btnArchiving_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (new Archiving(WorkWithFile.OpenFile()).ShowDialog() != DialogResult.OK)
                this.Show();
        }

        private void btnUnarchiving_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (new Unarchiving(WorkWithFile.OpenFile()).ShowDialog() != DialogResult.OK)
                this.Show();
        }

    }
}