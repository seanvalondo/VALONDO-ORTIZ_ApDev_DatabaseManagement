using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double total = 0;
        int TransactionNo = 0;
        double Change = 0;
        private bool groupBoxOpen = false;
        public Form1()
        {
            InitializeComponent();
           
            BindGrid();
            button13.Enabled = false;
            groupBox1.Visible = false;
           
        }

  

        private void button1_Click(object sender, EventArgs e) // PEPSI
        {
            double Amount = 0;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Quantity for Pepsi: ");
            }
            else
            {
                int quantity = int.Parse(textBox1.Text);
                int availableQuantity = GetStockQuantity("Pepsi");
                if (availableQuantity < quantity)
                {
                    MessageBox.Show("Insufficient stock for Pepsi");
                    return;
                }

                total = 40 * quantity + total;
                Amount = 40 * quantity;
                textBox9.Text = total.ToString();

                dataGridView1.Rows.Add(TransactionNo, "Pepsi", 40.00, textBox1.Text, Amount, DateTime.Now);

            }

        }

        private void button2_Click(object sender, EventArgs e) // COCA-COLA
        {
            double Amount = 0;
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter Quantity for Coca-Cola: ");
            }
            else
            {
                int quantity = int.Parse(textBox2.Text);
                int availableQuantity = GetStockQuantity("Coca-Cola");
                if (availableQuantity < quantity)
                {
                    MessageBox.Show("Insufficient stock for Coca-Cola");
                    return;
                }

                total = 55 * quantity + total;
                Amount = 55 * quantity;
                textBox9.Text = total.ToString();

                dataGridView1.Rows.Add(TransactionNo, "Coca-Cola", 55.00, textBox2.Text, Amount, DateTime.Now);
               
            }

        }

        private void button3_Click(object sender, EventArgs e) // SPRITE
        {
            double Amount = 0;
            if (textBox3.Text == "")
            {
                MessageBox.Show("Enter Quantity for Sprite: ");
            }
            else
            {
                int quantity = int.Parse(textBox3.Text);
                int availableQuantity = GetStockQuantity("Sprite");
                if (availableQuantity < quantity)
                {
                    MessageBox.Show("Insufficient stock for Sprite");
                    return;
                }

                total = 49 * quantity + total;
                Amount = 49 * quantity;
                textBox9.Text = total.ToString();

                dataGridView1.Rows.Add(TransactionNo, "Sprite", 49.00, textBox3.Text, Amount, DateTime.Now);
            
            }
        }

        private void button4_Click(object sender, EventArgs e) // ROYAL
        {
            double Amount = 0;
            if (textBox4.Text == "")
            {
                MessageBox.Show("Enter Quantity for Royal: ");
            }
            else
            {
                int quantity = int.Parse(textBox4.Text);
                int availableQuantity = GetStockQuantity("Royal");
                if (availableQuantity < quantity)
                {
                    MessageBox.Show("Insufficient stock for Royal");
                    return;
                }

                total = 45 * quantity + total;
                Amount = 45 * quantity;
                textBox9.Text = total.ToString();

                dataGridView1.Rows.Add(TransactionNo, "Royal", 45.00, textBox4.Text, Amount, DateTime.Now);
            
            }

        }

        private void button5_Click(object sender, EventArgs e) // BEEF NACHOS
        {
            double Amount = 0;
            if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Quantity for Beef Nachos: ");
            }
            else
            {
                int quantity = int.Parse(textBox5.Text); 

                int availableTortillaChips = GetStockQuantity("Tortilla Chips");
                int availableGroundBeef = GetStockQuantity("Ground Beef");
                int availableCheese = GetStockQuantity("Cheese");
                int availableTomatoes = GetStockQuantity("Tomatoes");

                if (availableTortillaChips < quantity || availableGroundBeef < quantity || availableCheese < quantity || availableTomatoes < quantity)
                {
                    MessageBox.Show("Insufficient stock for Beef Nachos");
                    return;
                }

              
                

                total = 150 * quantity + total;
                Amount = 150 * quantity;
                textBox9.Text = total.ToString();

                dataGridView1.Rows.Add(TransactionNo, "Beef Nachos", 150.00, textBox5.Text, Amount, DateTime.Now);
            }

        }

        private void button6_Click(object sender, EventArgs e) // FRIES
        {
            double Amount = 0;
            if (textBox6.Text == "")
            {
                MessageBox.Show("Enter Quantity for Fries: ");
            }
            else
            {
                int quantity = int.Parse(textBox6.Text); 

               
                int availablePotatoes = GetStockQuantity("Potatoes");
                int availableVegetableOil = GetStockQuantity("Vegetable Oil");
                int availableSalt = GetStockQuantity("Salt");

                if (availablePotatoes < quantity || availableVegetableOil < quantity || availableSalt < quantity)
                {
                    MessageBox.Show("Insufficient stock for Fries");
                    return;
                }

            
                total = 90 * quantity + total;
                Amount = 90 * quantity;
                textBox9.Text = total.ToString();

                dataGridView1.Rows.Add(TransactionNo, "Fries", 90.00, textBox6.Text, Amount, DateTime.Now);
            }

        }

        private void button7_Click(object sender, EventArgs e) // CLUB SANDWICH
        {
            double Amount = 0;
            if (textBox7.Text == "")
            {
                MessageBox.Show("Enter Quantity for Club Sandwich: ");
            }
            else
            {
                int quantity = int.Parse(textBox7.Text); 

                
                int availableBread = GetStockQuantity("Bread");
                int availableChicken = GetStockQuantity("Chicken");
                int availableLettuce = GetStockQuantity("Lettuce");
                int availableTomato = GetStockQuantity("Tomatoes");
                int availableMayonnaise = GetStockQuantity("Mayonnaise");
                int availableCheese = GetStockQuantity("Cheese");

                if (availableBread < quantity || availableChicken < quantity || availableLettuce < quantity || availableTomato < quantity || availableMayonnaise < quantity || availableCheese < quantity)
                {
                    MessageBox.Show("Insufficient stock for Club Sandwich");
                    return;
                }


                total = 160 * quantity + total;
                Amount = 160 * quantity;
                textBox9.Text = total.ToString();

                dataGridView1.Rows.Add(TransactionNo, "Club Sandwich", 160.00, textBox7.Text, Amount, DateTime.Now);
            }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            double Amount = 0;
            if (textBox8.Text == "")
            {
                MessageBox.Show("Enter Quantity for Breakfast Burrito: "); // BREAKFAST BURRITO
            }
            else
            {
                int quantity = int.Parse(textBox8.Text); 

              
                int availableTortilla = GetStockQuantity("Tortilla");
                int availableEggs = GetStockQuantity("Eggs");
                int availableBacon = GetStockQuantity("Bacon");
                int availableCheese = GetStockQuantity("Cheese");

                if (availableTortilla < quantity || availableEggs < quantity || availableBacon < quantity || availableCheese < quantity)
                {
                    MessageBox.Show("Insufficient stock for Breakfast Burrito");
                    return;
                }

       

                total = 150 * quantity + total;
                Amount = 150 * quantity;
                textBox9.Text = total.ToString();

                dataGridView1.Rows.Add(TransactionNo, "Breakfast Burrito", 150.00, textBox8.Text, Amount, DateTime.Now);
            }

        }

        private void button9_Click(object sender, EventArgs e)
        {
            total = 0;
            button1.Enabled = true;
            button2.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;
            button5.Enabled = true;
            button6.Enabled = true;
            button7.Enabled = true;
            button8.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "0";
            textBox11.Text = "";
            textBox12.Text = "";
            dataGridView1.Rows.Clear();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rmd = new Random();
            TransactionNo = rmd.Next();
            
        }

        private void button10_Click(object sender, EventArgs e) // RECORD ORDER
        {

            string constring = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO CustomerOrder(TNO, Item, Price, Qty, Amount, DateOrdered) VALUES (@TNO, @Item, @Price, @Qty, @Amount, @DateOrdered)", con))
                {
                    cmd.Parameters.Add(new SqlParameter("@TNO", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@Item", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Money));
                    cmd.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money));
                    cmd.Parameters.Add(new SqlParameter("@DateOrdered", SqlDbType.DateTime));
                    con.Open();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            cmd.Parameters["@TNO"].Value = row.Cells[0].Value;
                            cmd.Parameters["@Item"].Value = row.Cells[1].Value;
                            cmd.Parameters["@Price"].Value = row.Cells[2].Value;
                            cmd.Parameters["@Qty"].Value = row.Cells[3].Value;
                            cmd.Parameters["@Amount"].Value = row.Cells[4].Value;
                            cmd.Parameters["@DateOrdered"].Value = row.Cells[5].Value;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }
            button13.Enabled = true;
            MessageBox.Show("Processed Successfully!");
            
        }


        private void BindGrid()
        {
            string constring = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Sales",con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dataGridView2.DataSource = dt;
                    con.Close();
                }

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Ingredients", con))
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


        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e) // PAYMENT BUTTON
        {
            double paymentAmount = 0;
            if (!double.TryParse(textBox11.Text, out paymentAmount))
            {
                MessageBox.Show("Please enter a valid payment amount.");
                return;
            }

            
            double totalAmount = CalculateTotalAmount();

            
            if (paymentAmount < totalAmount)
            {
                MessageBox.Show("Insufficient funds for the purchase.");
                return;
            }

            // Process the payment
            ProcessPayment(totalAmount);

            // Calculate change
            double change = paymentAmount - totalAmount;
            textBox12.Text = change.ToString("0.00");


            DeductIngredientsForSelectedItems();
            UpdateStock();


            // Record to Sales
            string constring = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Sales(TNO, Item, Price, Qty, Amount, DatePurchased) VALUES(@TNO, @Item,@Price, @Qty, @Amount, @DatePurchased)", con))
                {
                    cmd.Parameters.Add(new SqlParameter("@TNO", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@Item", SqlDbType.VarChar));
                    cmd.Parameters.Add(new SqlParameter("@Price", SqlDbType.Money));
                    cmd.Parameters.Add(new SqlParameter("@Qty", SqlDbType.Int));
                    cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Money));
                    cmd.Parameters.Add(new SqlParameter("@DatePurchased", SqlDbType.DateTime));
                    con.Open();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            cmd.Parameters["@TNO"].Value = row.Cells[0].Value;
                            cmd.Parameters["@Item"].Value = row.Cells[1].Value;
                            cmd.Parameters["@Price"].Value = row.Cells[2].Value;
                            cmd.Parameters["@Qty"].Value = row.Cells[3].Value;
                            cmd.Parameters["@Amount"].Value = row.Cells[4].Value;
                            cmd.Parameters["@DatePurchased"].Value = row.Cells[5].Value;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
            }


            MessageBox.Show("Payment and Record Successful!");
            BindGrid();
            button13.Enabled = false;
        }

        private int GetStockQuantity(string Ingredient)
        {
            int quantity = 0;
            string constring = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT Quantity FROM Ingredients WHERE Ingredient = @Ingredient";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Ingredient", Ingredient);
                 
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        quantity = Convert.ToInt32(result);
                    }
                }
            }
            return quantity;
        }



        private void UpdateStockQuantity(string Ingredient, int quantity)
        {
            string constring = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "UPDATE Ingredients SET Quantity = @Quantity WHERE Ingredient = @Ingredient";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Ingredient", Ingredient);
                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void DeductIngredientsForSelectedItems()
        {
           
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    string itemName = row.Cells["Item"].Value.ToString();
                    int quantity = int.Parse(row.Cells["Qty"].Value.ToString());

                    
                    if (itemName == "Beef Nachos")
                    {
                        UpdateStockQuantity("Tortilla Chips", GetStockQuantity("Tortilla Chips") - quantity);
                        UpdateStockQuantity("Cheese", GetStockQuantity("Cheese") - quantity);
                        UpdateStockQuantity("Ground Beef", GetStockQuantity("Ground Beef") - quantity);
                        UpdateStockQuantity("Tomatoes", GetStockQuantity("Tomatoes") - quantity);
                    }
                    else if (itemName == "Fries")
                    {
                        UpdateStockQuantity("Potatoes", GetStockQuantity("Potatoes") - quantity);
                        UpdateStockQuantity("Vegetable Oil", GetStockQuantity("Vegetable Oil") - quantity);
                        UpdateStockQuantity("Salt", GetStockQuantity("Salt") - quantity);
                    }
                    else if (itemName == "Club Sandwich")
                    {
                        UpdateStockQuantity("Bread", GetStockQuantity("Bread") - quantity);
                        UpdateStockQuantity("Chicken", GetStockQuantity("Chicken") - quantity);
                        UpdateStockQuantity("Lettuce", GetStockQuantity("Lettuce") - quantity);
                        UpdateStockQuantity("Tomatoes", GetStockQuantity("Tomatoes") - quantity);
                        UpdateStockQuantity("Cheese", GetStockQuantity("Cheese") - quantity);
                    }
                    else if (itemName == "Breakfast Burrito")
                    {
                        UpdateStockQuantity("Tortilla", GetStockQuantity("Tortilla") - quantity);
                        UpdateStockQuantity("Eggs", GetStockQuantity("Eggs") - quantity);
                        UpdateStockQuantity("Bacon", GetStockQuantity("Bacon") - quantity);
                        UpdateStockQuantity("Cheese", GetStockQuantity("Cheese") - quantity);
                    }
                    else if (itemName == "Pepsi" || itemName == "Coca-Cola" || itemName == "Sprite" || itemName == "Royal")
                    {
                        UpdateStockQuantity(itemName, GetStockQuantity(itemName) - quantity);
                    }

                }
            }
        }
        private void ProcessPayment(double totalAmount)
        {

            total = totalAmount;
            textBox9.Text = total.ToString();


        }

        private double CalculateTotalAmount()
        {
            double totalAmount = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    double itemAmount = Convert.ToDouble(row.Cells["Amount"].Value);
                    totalAmount += itemAmount;
                }
            }
            return totalAmount;
        }
        private void UpdateStock()
        {

            string constring = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";

            try
            {
                using (SqlConnection con = new SqlConnection(constring))
                {

                    con.Open();


                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string itemName = row.Cells["Item"].Value.ToString();
                            int quantity = Convert.ToInt32(row.Cells["Qty"].Value);


                            string query = "UPDATE Ingredients SET Quantity = Quantity - @Quantity WHERE Ingredient = @Ingredient";
                            using (SqlCommand cmd = new SqlCommand(query, con))
                            {
                               
                                cmd.Parameters.AddWithValue("@Quantity", quantity);
                                cmd.Parameters.AddWithValue("@Ingredient", itemName);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating stock: " + ex.Message);
            }
            BindGrid();
        }
        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            this.Close();
            Form f3 = new Form3();
            f3.Show();
            
        }

       

        private void button14_Click(object sender, EventArgs e)
        {
            
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            if (groupBoxOpen)
            {
               
                groupBox1.Visible = false;
                groupBoxOpen = false;
            }
            else
            {
                
                groupBox1.Visible = true;
                groupBoxOpen = true;
            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            string searchTerm = textBox10.Text;
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


                        dataGridView3.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
