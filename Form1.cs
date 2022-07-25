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

namespace DatabaseManager
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;initial catalog=CarPrices;integrated security=true");

        public Form1()
        {
            InitializeComponent();
           
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {

            string sql = tbxQuery.Text;
            display(sql);
        }
        public void display(string sorgu)
        {
            try
            {
                var dt = new DataTable();
                getCon();
                var adp = new SqlDataAdapter($"{sorgu}", con);
                adp.Fill(dt);
                dtgw.DataSource = dt;
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void getCon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxQuery.Text = "";
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            tbxQuery.Text= "Select * from Cars";
            string sql = "Select * from Cars";
            display(sql);
        }
    }
}
