using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace perpustakaan
{
    public partial class AddStudents : Form
    {
        public AddStudents()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "Alert",MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }

        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStudentName.Clear();
            txtStudentNumb.Clear();
            txtDept.Clear();
            txtSemester.Clear();
            txtContact.Clear();
            //txtEmail.Clear();

            txtEmail.Text = "";
        }

        private void btnSaveInfo_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text != ""&& txtStudentNumb.Text != "" && txtDept.Text != "" && txtSemester.Text != "" && txtContact.Text != "" && txtEmail.Text != "")
            {
                String name = txtStudentName.Text;
                String snum = txtStudentNumb.Text;
                String dept = txtDept.Text;
                String sem = txtSemester.Text;
                Int64 mobile = Int64.Parse(txtContact.Text);
                String email = txtEmail.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = JUNIOR; database = Perpustakaan; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;


                con.Open();
                cmd.CommandText = "insert into NewStudent (sname, snumber,dep, sm, contact, email) values ('" + name + "','" + snum + "','" + dept + "','" + sem + "','" + mobile + "','" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Save!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please Fill the Empty Feilds", "Suggest", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

            
        }
    }
}
