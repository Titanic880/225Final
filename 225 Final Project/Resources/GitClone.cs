using System;
using System.Windows.Forms;

namespace _225_Final_Project.Resources
{
    public partial class GitClone : Form
    {
        public GitClone()
        {
            InitializeComponent();
        }

        private void BtnRun_Click(object sender, EventArgs e)
        {
            if (PowerShell.GitClone(tbLink.Text))
            {
                MessageBox.Show("Cloned the repository!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Please check the Repository link!" +
            Environment.NewLine + "Check ErrorLog for more information");
            }
        }
    }
}
