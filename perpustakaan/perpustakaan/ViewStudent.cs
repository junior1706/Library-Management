using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace perpustakaan
{
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            SqlConnection con  = new SqlConnection();
            con.ConnectionString = "data source = JUNIOR; database = Perpustakaan; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void txtStudentName_TextChanged(object sender, EventArgs e)
        {
            if(txtStudentName.Text != "")
            {
                label1.Visible = false;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = JUNIOR; database = Perpustakaan; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where snumber LIKE '" + txtStudentName.Text + "%' ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                label1.Visible = true;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = JUNIOR; database = Perpustakaan; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            
        }

        int bid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = JUNIOR; database = Perpustakaan; integrated security = True";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewStudent where stuid = "+bid+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtSName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtSNumb.Text = ds.Tables[0].Rows[0][2].ToString();
            txtDepartement.Text = ds.Tables[0].Rows[0][3].ToString();
            txtSemester.Text = ds.Tables[0].Rows[0][4].ToString();
            txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0][6].ToString();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            String sname = txtSName.Text;
            String snum = txtSNumb.Text;
            String dep = txtDepartement.Text;
            String sem = txtSemester.Text;
            Int64 contact = Int64.Parse(txtContact.Text);
            String semail = txtEmail.Text;

            if (MessageBox.Show("Data Will Be Update. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = JUNIOR; database = Perpustakaan; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewStudent set sname ='" + sname + "', snumber = '" + snum + "', dep = '" + dep + "', sm = '" + sem + "', contact = '" + contact + "', email = '" + semail + "' where stuid = " + rowid + " ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudent_Load(this, null);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ViewStudent_Load(this, null);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will Be Deleted. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = JUNIOR; database = Perpustakaan; integrated security = True";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewStudent where stuid = " + rowid + " ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudent_Load(this, null);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Unsave", "Are You Sure Want To Leave?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
