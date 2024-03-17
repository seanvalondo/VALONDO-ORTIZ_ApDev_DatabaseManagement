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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
            BindGrid();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void BindGrid()
        {

            string constring = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";

            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM RecordSupply", con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    decimal totalSales = CalculateTotalSales(dt);
                    textBox1.Text = totalSales.ToString("C");
                    con.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime begining = dateTimePicker1.Value.Date;
            //MessageBox.Show(begining.ToString());
            DateTime ending = dateTimePicker2.Value.Date;

            string constring = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";

            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT * FROM RecordSupply WHERE DatePurchased BETWEEN @BeginDate AND @EndDate";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@BeginDate", begining);
                    cmd.Parameters.AddWithValue("@EndDate", ending.AddDays(1));
                    //cmd.CommandType = CommandType.Text;
                    con.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    adapter.Fill(dt);
                    dataGridView1.DataSource = dt;
                    decimal totalSales = CalculateTotalSales(dt);
                    textBox1.Text = totalSales.ToString("C");
                    con.Close();
                }
            }
        }


        private decimal CalculateTotalSales(DataTable salesData)
        {
            decimal totalSales = 0;
            foreach (DataRow row in salesData.Rows)
            {
                totalSales += Convert.ToDecimal(row["Amount"]);
            }
            return totalSales;
        }
    }
}
