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
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = JUNIOR; database = Perpustakaan; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select bName from NewBook", con);
            SqlDataReader Sdr = cmd.ExecuteReader();

            while (Sdr.Read())
            {
                for (int i = 0; i < Sdr.FieldCount; i++)
                {
                    cmbBookName.Items.Add(Sdr.GetString(i));
                }
            }
            Sdr.Close();
            con.Close();
        }

        int count;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtStudentNumb.Text != "")
            {
                String eid = txtStudentNumb.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = JUNIOR; database = Perpustakaan; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where snum = '"+eid+"' ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                //
                cmd.CommandText = "select count(std_number) from IRBook where std_email = '" + eid + "' and book_return_date is null ";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);

                count = int.Parse(ds1.Tables[0].Rows[0][0].ToString());
                //

                if (ds.Tables[0].Rows.Count != 0 )
                {
                    txtStudentName.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDept.Text = ds.Tables[0].Rows[0][3].ToString();
                    txtSemester.Text = ds.Tables[0].Rows[0][4].ToString();
                    txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][1].ToString();
                }
                else
                {
                    txtStudentName.Clear();
                    txtStudentNumb.Clear();
                    txtDept.Clear();
                    txtSemester.Clear();
                    txtContact.Clear();
                    txtEmail.Clear();
                    MessageBox.Show("Invalid Student Number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (txtStudentName.Text != "")
            {
                if (cmbBookName.SelectedIndex != -1 && count <= 2)
                {
                    String snumb = txtStudentNumb.Text;
                    String sname = txtStudentName.Text;
                    String sdept = txtDept.Text;
                    String sem = txtSemester.Text;
                    Int64 contact = Int64.Parse(txtContact.Text);
                    String email = txtEmail.Text;
                    String bookname = cmbBookName.Text;
                    String bookissuedate = dtIssue.Text;

                    String eid = txtStudentNumb.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source = JUNIOR; database = Perpustakaan; integrated security = True";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = cmd.CommandText = "insert into IRBook (std_number, std_name, std_dept, std_sem, std_contact, std_email, bookname, book_issue_date,book_return_date) values ('" + snumb + "','" + sname + "','" + sdept + "','" + sem + "','" + contact + "','" + email + "','" + bookname + "','" + bookissuedate + "'";
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issue", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Select Book Or Maximum Number of Book Has Been Issue", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtStudentNumb_TextChanged(object sender, EventArgs e)
        {
            if(txtStudentNumb.Text == "")
            {
                txtStudentName.Clear();
                txtDept.Clear();
                txtSemester.Clear();
                txtContact.Clear();
                txtEmail.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStudentNumb.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
