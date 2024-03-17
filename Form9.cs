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

namespace WindowsFormsApp1
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            BindGrid();
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBox1.Text;
            string connectionString = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";

            // SQL query to fetch filtered data based on the search term
            string query = "SELECT * FROM Ingredients WHERE Quantity LIKE @Quantity OR Price LIKE @Price OR Ingredient LIKE @Ingredient";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameters to the command for the search term
                    command.Parameters.AddWithValue("@Quantity", "%" + searchTerm + "%");
                    command.Parameters.AddWithValue("@Price", "%" + searchTerm + "%");
                    command.Parameters.AddWithValue("@Ingredient", "%" + searchTerm + "%");

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        
                        dataGridView1.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void BindGrid()
        {
            string constring = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";
            string query = "SELECT * FROM Ingredients"; 

            using (SqlConnection connection = new SqlConnection(constring))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }
    }
}