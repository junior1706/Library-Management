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
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBookName.Text != "" && txtAuthor.Text != "" && txtPublisher.Text != "" && txtPrice.Text != "" && txtQuantity.Text != "")
            {

                string bname = txtBookName.Text;
                string bauthor = txtAuthor.Text;
                string publisher = txtPublisher.Text;
                string pdate = dtPurshe.Text;
                Int64 price = Int64.Parse(txtPrice.Text);
                Int64 quantity = Int64.Parse(txtQuantity.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source = JUNIOR; database = Perpustakaan;integrated security=True";
                SqlCommand cmd = con.CreateCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewBook (bName,bAuthor,bPubl,bPDate,bPrice,bQuant) values ('" + bname + "','" + bauthor + "','" + publisher + "','" + pdate + "','" + price + "','" + quantity + "')";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Telah Disimpan", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBookName.Clear();
                txtAuthor.Clear();
                txtPublisher.Clear();
                txtPrice.Clear();
                txtQuantity.Clear();
            }
            else
            {
                MessageBox.Show("Tolong Diisi Semua!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
