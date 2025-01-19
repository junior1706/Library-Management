using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace perpustakaan
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("anda yankin ingin keluar??","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
            }

            Application.Exit();
        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dashboard_Load(object sender, EventArgs e)
        {

        }

        private void addBoksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddBooks abs = new AddBooks();
            abs.Show();
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewBook abs = new ViewBook();
            abs.Show();
        }

        private void addStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddStudents abs = new AddStudents();
            abs.Show();
        }

        private void viewStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewStudent abs = new ViewStudent();
            abs.Show();
        }

        private void returnBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBook abs = new IssueBook();
            abs.Show();
        }

        private void returnBooksToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ReturnBook abs = new ReturnBook();
            abs.Show();
        }

        private void completeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CompliteBook abs = new CompliteBook();
            abs.Show();
        }
    }
}
