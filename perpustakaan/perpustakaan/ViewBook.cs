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
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = JUNIOR; database = Perpustakaan;integrated security=True";
            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewBook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }
        int bid;
        Int64 rowid;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = JUNIOR; database = Perpustakaan;integrated security=True";
            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from NewBook"+bid+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());
            
            txtBName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtAuthor.Text = ds.Tables[0].Rows[0][1].ToString();
            txtPublisher.Text = ds.Tables[0].Rows[0][1].ToString();
            txtPdate.Text = ds.Tables[0].Rows[0][1].ToString();
            txtPrice.Text = ds.Tables[0].Rows[0][1].ToString();
            txtQuantity.Text = ds.Tables[0].Rows[0][1].ToString();
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            panel2.Visible=false;
        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {
            if (txtBookName.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = JUNIOR; database = Perpustakaan;integrated security=True";
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewBook where bName LIKE '"+txtBookName.Text+"%";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];
            }
            else 
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = JUNIOR; database = Perpustakaan;integrated security=True";
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewBook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables;

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtBookName.Clear();
            panel2.Visible = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string bname = txtBookName.Text;
            string bauthor = txtAuthor.Text;
            string publisher = txtPublisher.Text;
            string pdate = txtPdate.Text;
            Int64 price = Int64.Parse(txtPrice.Text);
            Int64 quantity = Int64.Parse(txtQuantity.Text);

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source = JUNIOR; database = Perpustakaan;integrated security=True";
            SqlCommand cmd = con.CreateCommand();
            cmd.Connection = con;

            cmd.CommandText = "update NewBook set bName = '" + bname + "',bAuthor = '" + bauthor + "', bPubl = '" + publisher + "', bPDate = '" + pdate + "',bPrice = '" + pdate + ", bQuant = " + quantity + " where bid= "+rowid+"";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

        }
    }
}
