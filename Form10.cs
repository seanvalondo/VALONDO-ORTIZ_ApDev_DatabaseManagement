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

namespace WindowsFormsApp1
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
            BindGrid();
            comboBox1.Items.Add("Customer");
            comboBox1.Items.Add("Cashier");
            comboBox1.Items.Add("Owner");

        }

        private void Form10_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void BindGrid()
        {
            string constring = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM login", con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dataGridView1.DataSource = dt;
                    con.Close();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM TimeLog", con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Payroll", con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dataGridView3.DataSource = dt;
                    con.Close();
                }
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-QH7OIAV\\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO login values (@userid, @fname, @lname,@uname, @pword, @userlev)", con); // Added closing parenthesis here
            cmd.Parameters.AddWithValue("@userid", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@fname", textBox2.Text);
            cmd.Parameters.AddWithValue("@lname", textBox3.Text);
            cmd.Parameters.AddWithValue("@uname", textBox4.Text);
            cmd.Parameters.AddWithValue("@pword", textBox5.Text);
            cmd.Parameters.AddWithValue("@userlev", comboBox1.SelectedItem.ToString()); 
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Insert Successfully!");
            BindGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-QH7OIAV\\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE login SET fname=@fname, lname=@lname, uname=@uname, pword=@pword, userlev=@userlev WHERE userid = @userid", con);
            cmd.Parameters.AddWithValue("@fname", textBox2.Text);
            cmd.Parameters.AddWithValue("@lname", textBox3.Text);
            cmd.Parameters.AddWithValue("@uname", textBox4.Text);
            cmd.Parameters.AddWithValue("@pword", textBox5.Text);
            cmd.Parameters.AddWithValue("@userlev", comboBox1.SelectedItem.ToString());
            cmd.Parameters.AddWithValue("@userid", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Update Successfully!");
            BindGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-QH7OIAV\\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete login where userid=@userid", con);
            cmd.Parameters.AddWithValue("@userid", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Deleted Successfully!");
            BindGrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string constring = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                con.Open();

                // Calculate the number of hours worked
                TimeSpan timeWorked = dateTimePicker5.Value - dateTimePicker3.Value;
                double hoursWorked = timeWorked.TotalHours;

                // Hourly rate
                double hourlyRate = 30.0;

                // Calculate total amount
                double totalAmount = hoursWorked * hourlyRate;

                // Insert into TimeLog table
                SqlCommand cmd = new SqlCommand("INSERT INTO TimeLog (userid, LogDate, StartTime, EndTime) VALUES (@userid, @LogDate, @StartTime, @EndTime)", con);
                cmd.Parameters.AddWithValue("@userid", textBox7.Text);
                cmd.Parameters.AddWithValue("@LogDate", DateTime.Today);
                cmd.Parameters.AddWithValue("@StartTime", dateTimePicker3.Value);
                cmd.Parameters.AddWithValue("@EndTime", dateTimePicker5.Value);
                cmd.ExecuteNonQuery();

                // Insert into Payroll table
                SqlCommand payrollCmd = new SqlCommand("INSERT INTO Payroll (userid, LogDate, HoursWorked, HourlyRate, TotalAmount) VALUES (@userid, @LogDate, @HoursWorked, @HourlyRate, @TotalAmount)", con);
                payrollCmd.Parameters.AddWithValue("@userid", textBox7.Text);
                payrollCmd.Parameters.AddWithValue("@LogDate", DateTime.Today);
                payrollCmd.Parameters.AddWithValue("@HoursWorked", hoursWorked);
                payrollCmd.Parameters.AddWithValue("@HourlyRate", hourlyRate);
                payrollCmd.Parameters.AddWithValue("@TotalAmount", totalAmount);
                payrollCmd.ExecuteNonQuery();

                MessageBox.Show("Time log and payroll information saved successfully.");
                BindGrid();

            }
        }

       

        private void button6_Click(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count > 0)
            {
              
                DataGridViewRow selectedRow = dataGridView3.SelectedRows[0];

                
                int userid = Convert.ToInt32(selectedRow.Cells["userid"].Value);

             
                Payroll(userid);

                dataGridView3.Rows.Remove(selectedRow);
                MessageBox.Show("Pay Successfully!");
                textBox6.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox12.Text = "";
            }
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
  

        private void Payroll(int userid)
        {
           
            string connectionString = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";
            string query = "DELETE FROM Payroll WHERE userid = @userid";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Add parameter
                    command.Parameters.AddWithValue("@userid", userid);

                    try
                    {
                        // Open the connection
                        connection.Open();

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        // Handle exceptions
                        MessageBox.Show("Error deleting record from database: " + ex.Message);
                    }
                }
            }
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBox12.Text;
            string connectionString = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";


            string query = "SELECT * FROM Payroll WHERE userid LIKE @userid"; // Adjust column names and table name

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userid", "%" + searchTerm + "%");

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);


                        dataGridView3.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
        
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBox7.Text;
            string connectionString = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";


            string query = "SELECT * FROM TimeLog WHERE userid LIKE @userid"; // Adjust column names and table name

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userid", "%" + searchTerm + "%");

                    try
                    {
                        connection.Open();
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);


                        dataGridView2.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView3.Rows.Count)
            {
                textBox12.Text = dataGridView3.Rows[e.RowIndex].Cells["userid"].Value.ToString();
                textBox9.Text = dataGridView3.Rows[e.RowIndex].Cells["HoursWorked"].Value.ToString();
                textBox6.Text = dataGridView3.Rows[e.RowIndex].Cells["HourlyRate"].Value.ToString();
                textBox10.Text = dataGridView3.Rows[e.RowIndex].Cells["TotalAmount"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            comboBox1.Text = "";
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBox11.Text;
            string connectionString = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";


            string query = "SELECT * FROM login WHERE userid LIKE @userid"; // Adjust column names and table name

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@userid", "%" + searchTerm + "%");

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
    }
}
