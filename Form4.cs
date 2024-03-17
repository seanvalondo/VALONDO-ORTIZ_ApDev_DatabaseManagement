using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {


        int TransactionNo = 0;
        double Change = 0;
        double total = 0;
        private bool groupBoxOpen = false;
        public Form4()
        {
            InitializeComponent();
            button11.Enabled = false;
            button13.Enabled = false;
            button15.Enabled = false;
            BindGrid();
            groupBox1.Visible = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Random rmd = new Random();
            TransactionNo = rmd.Next();
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






        private void BindGrid()
        {
            string constring = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Ingredients", con))
                {
                    cmd.CommandType = CommandType.Text;
                    con.Open();
                    DataTable dt = new DataTable();
                    dt.Load(cmd.ExecuteReader());
                    dataGridView2.DataSource = dt;
                    con.Close();
                }
            }
        }






        private void button12_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.Show();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            double Amount = 0;
            if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Quantity for Beef Nachos: ");
                return;
            }

            int quantity = int.Parse(textBox5.Text); 

        
            double tortillaChipsPrice = GetIngredientPrice("Tortilla Chips");
            double cheesePrice = GetIngredientPrice("Cheese");
            double groundBeefPrice = GetIngredientPrice("Ground Beef");
            double tomatoesPrice = GetIngredientPrice("Tomatoes");

          

            
            double tortillaChipsAmount = tortillaChipsPrice * quantity;
            double cheeseAmount = cheesePrice * quantity;
            double groundBeefAmount = groundBeefPrice * quantity;
            double tomatoesAmount = tomatoesPrice * quantity;

            
            dataGridView1.Rows.Add(TransactionNo, "Tortilla Chips", tortillaChipsPrice, textBox5.Text, tortillaChipsAmount, DateTime.Now);
            dataGridView1.Rows.Add(TransactionNo, "Cheese", cheesePrice, textBox5.Text, cheeseAmount, DateTime.Now);
            dataGridView1.Rows.Add(TransactionNo, "Ground Beef", groundBeefPrice, textBox5.Text, groundBeefAmount, DateTime.Now);
            dataGridView1.Rows.Add(TransactionNo, "Tomatoes", tomatoesPrice, textBox5.Text, tomatoesAmount, DateTime.Now);

            double totalAmount = tortillaChipsAmount + cheeseAmount + groundBeefAmount + tomatoesAmount;
            total += totalAmount;
            textBox9.Text = total.ToString();
        }

        private double GetIngredientPrice(string ingredientName)
        {
            double price = 0;
            string constring = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                string query = "SELECT Price FROM Ingredients WHERE Ingredient = @Ingredient";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Ingredient", ingredientName);
                    con.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        price = Convert.ToDouble(result);
                    }
                }
            }
            return price;
        }



        private void button9_Click_1(object sender, EventArgs e)
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
            textBoxPaymentAmount.Text = "";
            textBoxChange.Text = "";
            dataGridView1.Rows.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
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
                
               

                total = 30 * quantity + total;
                Amount = 30 * quantity;
                textBox9.Text = total.ToString();

                dataGridView1.Rows.Add(TransactionNo, "Pepsi", 30.00, textBox1.Text, Amount, DateTime.Now);

            }
        }



        private void button6_Click_1(object sender, EventArgs e)
        {
            double Amount = 0;
            if (textBox6.Text == "")
            {
                MessageBox.Show("Enter Quantity for Fries: ");
                return;
            }

            int quantity = int.Parse(textBox6.Text);

            double potatoesPrice = GetIngredientPrice("Potatoes");
            double vegetableOilPrice = GetIngredientPrice("Vegetable Oil");
            double saltPrice = GetIngredientPrice("Salt");

            double potatoesAmount = potatoesPrice * quantity;
            double vegetableOilAmount = vegetableOilPrice * quantity;
            double saltAmount = saltPrice * quantity;

            dataGridView1.Rows.Add(TransactionNo, "Potatoes", potatoesPrice, textBox6.Text, potatoesAmount, DateTime.Now);
            dataGridView1.Rows.Add(TransactionNo, "Vegetable Oil", vegetableOilPrice, textBox6.Text, vegetableOilAmount, DateTime.Now);
            dataGridView1.Rows.Add(TransactionNo, "Salt", saltPrice, textBox6.Text, saltAmount, DateTime.Now);

            double totalAmount = potatoesAmount + vegetableOilAmount + saltAmount;
            total += totalAmount;
          
            textBox9.Text = total.ToString();

            // Add the total amount of fries to the overall order total
          

        }


        private void button2_Click(object sender, EventArgs e)
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
                

                total = 35 * quantity + total;
                Amount = 35 * quantity;
                textBox9.Text = total.ToString();

                dataGridView1.Rows.Add(TransactionNo, "Coca-Cola", 35.00, textBox2.Text, Amount, DateTime.Now);
            
            }

        }

        private void button3_Click(object sender, EventArgs e)
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
                

                total = 28 * quantity + total;
                Amount = 28 * quantity;
                textBox9.Text = total.ToString();

                dataGridView1.Rows.Add(TransactionNo, "Sprite", 28.00, textBox3.Text, Amount, DateTime.Now);
            
            }

        }

        private void button4_Click(object sender, EventArgs e)
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
               

                total = 25 * quantity + total;
                Amount = 25 * quantity;
                textBox9.Text = total.ToString();

                dataGridView1.Rows.Add(TransactionNo, "Royal", 25.00, textBox4.Text, Amount, DateTime.Now);
                
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double Amount = 0;
            if (textBox7.Text == "")
            {
                MessageBox.Show("Enter Quantity for Club Sandwich: ");
                return;
            }

            int quantity = int.Parse(textBox7.Text);

            double breadPrice = GetIngredientPrice("Bread");
            double chickenPrice = GetIngredientPrice("Chicken");
            double lettucePrice = GetIngredientPrice("Lettuce");
            double tomatoPrice = GetIngredientPrice("Tomatoes");
            double mayonnaisePrice = GetIngredientPrice("Mayonnaise");
            double cheesePrice = GetIngredientPrice("Cheese");

            double breadAmount = breadPrice * quantity;
            double chickenAmount = chickenPrice * quantity;
            double lettuceAmount = lettucePrice * quantity;
            double tomatoAmount = tomatoPrice * quantity;
            double mayonnaiseAmount = mayonnaisePrice * quantity;
            double cheeseAmount = cheesePrice * quantity;

            dataGridView1.Rows.Add(TransactionNo, "Bread", breadPrice, textBox7.Text, breadAmount, DateTime.Now);
            dataGridView1.Rows.Add(TransactionNo, "Chicken", chickenPrice, textBox7.Text, chickenAmount, DateTime.Now);
            dataGridView1.Rows.Add(TransactionNo, "Lettuce", lettucePrice, textBox7.Text, lettuceAmount, DateTime.Now);
            dataGridView1.Rows.Add(TransactionNo, "Tomato", tomatoPrice, textBox7.Text, tomatoAmount, DateTime.Now);
            dataGridView1.Rows.Add(TransactionNo, "Mayonnaise", mayonnaisePrice, textBox7.Text, mayonnaiseAmount, DateTime.Now);
            dataGridView1.Rows.Add(TransactionNo, "Cheese", mayonnaisePrice, textBox7.Text, mayonnaiseAmount, DateTime.Now);

            double totalAmount = breadAmount + chickenAmount + lettuceAmount + tomatoAmount + mayonnaiseAmount + cheeseAmount;
            
            total += totalAmount;
            textBox9.Text = total.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            double Amount = 0;
            if (textBox8.Text == "")
            {
                MessageBox.Show("Enter Quantity for Breakfast Burrito: ");
                return;
            }

            int quantity = int.Parse(textBox8.Text);

            double tortillaPrice = GetIngredientPrice("Tortilla");
            double eggsPrice = GetIngredientPrice("Eggs");
            double baconPrice = GetIngredientPrice("Bacon");
            double cheesePrice = GetIngredientPrice("Cheese");

            double tortillaAmount = tortillaPrice * quantity;
            double eggsAmount = eggsPrice * quantity;
            double baconAmount = baconPrice * quantity;
            double cheeseAmount = cheesePrice * quantity;

            dataGridView1.Rows.Add(TransactionNo, "Tortilla", tortillaPrice, textBox8.Text, tortillaAmount, DateTime.Now);
            dataGridView1.Rows.Add(TransactionNo, "Eggs", eggsPrice, textBox8.Text, eggsAmount, DateTime.Now);
            dataGridView1.Rows.Add(TransactionNo, "Bacon", baconPrice, textBox8.Text, baconAmount, DateTime.Now);
            dataGridView1.Rows.Add(TransactionNo, "Cheese", cheesePrice, textBox8.Text, cheeseAmount, DateTime.Now);

            double totalAmount = tortillaAmount + eggsAmount + baconAmount + cheeseAmount;
           
            total += totalAmount;
            textBox9.Text = total.ToString();
        }

        private void button13_Click_1(object sender, EventArgs e)
        {
            double totalAmount = CalculateTotalAmount(); // Calculate the total amount of the selected items

            double paymentAmount = 0;
            if (!double.TryParse(textBoxPaymentAmount.Text, out paymentAmount))
            {
                MessageBox.Show("Please enter a valid payment amount.");
                return;
            }

            // Check if the payment amount is less than the total amount
            if (paymentAmount < totalAmount)
            {
                MessageBox.Show("Insufficient payment amount. Please pay the full amount.");
                return;
            }


            totalAmount = CalculateTotalAmount();


            ProcessPayment(totalAmount);


            double change = paymentAmount - totalAmount;
            textBoxChange.Text = change.ToString("0.00");
            button15.Enabled = true;
            button13.Enabled = false;

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


                            string query = "UPDATE Ingredients SET Quantity = Quantity + @Quantity WHERE Ingredient = @Ingredient";
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




        private void ProcessPayment(double totalAmount)
        {

            total = totalAmount;
            textBox9.Text = total.ToString();


        }







        private void button10_Click_1(object sender, EventArgs e)
        {
            string constring = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO OrderVendor(TNO, Item, Price, Qty, Amount, DateOrdered) VALUES (@TNO, @Item, @Price, @Qty, @Amount, @DateOrdered)", con))
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
                MessageBox.Show("Proccessed Successfully!");
                button13.Enabled = true;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }






        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
            Form f3 = new Form3();
            f3.Show();

        }


        private void button11_Click_1(object sender, EventArgs e)
        {
            string constring = @"Data Source=DESKTOP-QH7OIAV\SQLEXPRESS;database=VALONDO_VendingCola;Trusted_Connection=True";
            using (SqlConnection con = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO RecordSupply(TNO, Item, Price, Qty, Amount, DatePurchased) VALUES(@TNO, @Item,@Price, @Qty, @Amount, @DatePurchased)", con))
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
            BindGrid();
            MessageBox.Show("Recorded Successful!");
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


                        dataGridView2.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            if (groupBoxOpen)
            {
                // Close the GroupBox
                groupBox1.Visible = false;
                groupBoxOpen = false;
            }
            else
            {
                // Open the GroupBox
                groupBox1.Visible = true;
                groupBoxOpen = true;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            UpdateStock();
            BindGrid();
            AddIngredientsForSelectedItems();
            MessageBox.Show("Received!");
            button11.Enabled = true;
            button15.Enabled = false;
        }

        private void AddIngredientsForSelectedItems()
        {

            foreach (DataGridViewRow row in dataGridView2.Rows)
            {
                if (!row.IsNewRow)
                {
                    string itemName = row.Cells["Ingredient"].Value.ToString();
                    int quantity = int.Parse(row.Cells["Quantity"].Value.ToString());


                    if (itemName == "Beef Nachos")
                    {
                        UpdateStockQuantity("Tortilla Chips", GetStockQuantity("Tortilla Chips") + quantity);
                        UpdateStockQuantity("Cheese", GetStockQuantity("Cheese") + quantity);
                        UpdateStockQuantity("Ground Beef", GetStockQuantity("Ground Beef") + quantity);
                        UpdateStockQuantity("Tomatoes", GetStockQuantity("Tomatoes") + quantity);
                    }
                    else if (itemName == "Fries")
                    {
                        UpdateStockQuantity("Potatoes", GetStockQuantity("Potatoes") + quantity);
                        UpdateStockQuantity("Vegetable Oil", GetStockQuantity("Vegetable Oil") + quantity);
                        UpdateStockQuantity("Salt", GetStockQuantity("Salt") + quantity);
                    }
                    else if (itemName == "Club Sandwich")
                    {
                        UpdateStockQuantity("Bread", GetStockQuantity("Bread") + quantity);
                        UpdateStockQuantity("Chicken", GetStockQuantity("Chicken") + quantity);
                        UpdateStockQuantity("Lettuce", GetStockQuantity("Lettuce") + quantity);
                        UpdateStockQuantity("Tomatoes", GetStockQuantity("Tomatoes") + quantity);
                        UpdateStockQuantity("Cheese", GetStockQuantity("Cheese") + quantity);
                    }
                    else if (itemName == "Breakfast Burrito")
                    {
                        UpdateStockQuantity("Tortilla", GetStockQuantity("Tortilla") + quantity);
                        UpdateStockQuantity("Eggs", GetStockQuantity("Eggs") + quantity);
                        UpdateStockQuantity("Bacon", GetStockQuantity("Bacon") + quantity);
                        UpdateStockQuantity("Cheese", GetStockQuantity("Cheese") + quantity);
                    }
                    else if (itemName == "Pepsi" || itemName == "Coca-Cola" || itemName == "Sprite" || itemName == "Royal")
                    {
                        UpdateStockQuantity(itemName, GetStockQuantity(itemName) + quantity);
                    }

                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}


