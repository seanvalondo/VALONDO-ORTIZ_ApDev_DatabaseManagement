using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f4 = new Form4();
            f4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form f2 = new Form2();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form f9 = new Form9();
            f9.Show();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            this.Close();
            Form f3 = new Form3();
            f3.Show();
            
        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            Form f1 = new Form1();
            f1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form f10 = new Form10();
            f10.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form f8 = new Form8();
            f8.Show();
        }
    }
}
