using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programmingassignment
{
    public partial class UserControl3billing : UserControl
    {
        // database function declaration

        function fn = new function();
        string query;

        //


        public UserControl3billing()
        {
            InitializeComponent();
        }

        private void UserControl3billing_Load(object sender, EventArgs e)
        {

        }

        // Search the items //
        private void txtSearchBox_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            query = "select item_name from items where item_name like'" + txtSearchBox.Text + "%'";
            DataSet ds = fn.GetData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }


        }
        // add items details to quantity changing grid inorder to provide qty by the user to be added for the bill

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textboxItemQuantity.ResetText();
            textBoxTotal.Clear();

            string text = listBox1.GetItemText(listBox1.SelectedItem);
            textboxItemName.Text = text;
            query = "select item_price from items where item_name = '" + text + "'";
            DataSet ds = fn.GetData(query);


            textboxItemPrice.Text = ds.Tables[0].Rows[0][0].ToString();


        }

        // Changes total price on the above box if the qty is changed

        private void textboxItemQuantity_ValueChanged(object sender, EventArgs e)
        {
            if (decimal.TryParse(textboxItemPrice.Text, out decimal price))
            {
                decimal qty = textboxItemQuantity.Value;
                textBoxTotal.Text = (qty * price).ToString("0.##");
            }
            else
            {
                MessageBox.Show("Invalid item price.");
            }
        }




        // Adding Items from above quantity row to the bill grid

        private decimal total = 0;
        private decimal totalWithTax = 0;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Add a new row to the DataGridView
            int n = dataGridView1.Rows.Add();

            // Add Bill row with item details
            dataGridView1.Rows[n].Cells[0].Value = textboxItemName.Text;
            dataGridView1.Rows[n].Cells[1].Value = textboxItemPrice.Text;
            dataGridView1.Rows[n].Cells[2].Value = textboxItemQuantity.Text;
            dataGridView1.Rows[n].Cells[3].Value = textBoxTotal.Text;

            // For decimal conversion
            string totalText = textBoxTotal.Text;

            // Try parsing the textBoxTotal.Text as a decimal
            if (decimal.TryParse(totalText, out decimal currentItemTotal))
            {
                // Add the current item total to the overall total
                total += currentItemTotal;

                // Calculate tax amount (10%)
                decimal taxAmount = currentItemTotal * 0.10m;

                // Calculate total with tax
                decimal currentItemTotalWithTax = currentItemTotal + taxAmount;

                // Add the current item total with tax to the overall total with tax
                totalWithTax += currentItemTotalWithTax;

                // Update the labels with the formatted taxable amount and total with tax amount
                TotalTaxableAmt.Text = "Rs " + total.ToString("0.00");
                labelTotalAmount.Text = "Rs " + totalWithTax.ToString("0.00");
            }
            else
            {
                // Show an error message if the total value is invalid
                MessageBox.Show("Invalid total value. Please enter a valid decimal number.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printDocument1.Print();

        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {
            // Define fonts and brush
            Font headerFont = new Font("Arial", 16, FontStyle.Bold);
            Font font = new Font("Courier New", 12); // Monospaced font for better alignment
            Brush brush = Brushes.Black;

            // Define the initial position to start printing
            float startX = 50;
            float startY = 50;
            float offset = 20;

            // Print the header
            e.Graphics.DrawString("Receipt", headerFont, brush, startX, startY);
            startY += offset;

            e.Graphics.DrawString(new string('-', 40), font, brush, startX, startY);
            startY += offset;

            // Print the table headers
            string header = $"{"Item",-20}{"Unit Price",10}{"Qty",5}{"Total",10}";
            e.Graphics.DrawString(header, font, brush, startX, startY);
            startY += offset;

            e.Graphics.DrawString(new string('-', 40), font, brush, startX, startY);
            startY += offset;

            // Print each item from the DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string itemName = row.Cells["Column1"].Value.ToString();
                string unitPrice = row.Cells["Column2"].Value.ToString();
                string quantity = row.Cells["Column3"].Value.ToString();
                string total = row.Cells["Column4"].Value.ToString();

                // Format item details to align as a table
                string itemDetails = $"{itemName,-20}{unitPrice,10}{quantity,5}{total,10}";
                e.Graphics.DrawString(itemDetails, font, brush, startX, startY);
                startY += offset;
            }

            e.Graphics.DrawString(new string('-', 40), font, brush, startX, startY);
            startY += offset;

            // Print the taxable amount
            string taxableAmount = $"{"Taxable Amount:",-20}{TotalTaxableAmt.Text,15}";
            e.Graphics.DrawString(taxableAmount, font, brush, startX, startY);
            startY += offset;

            // Print the total amount
            string totalAmount = $"{"Total (with tax):",-20}{labelTotalAmount.Text,15}";
            e.Graphics.DrawString(totalAmount, font, brush, startX, startY);
            startY += offset;

            e.Graphics.DrawString(new string('-', 40), font, brush, startX, startY);
            startY += offset;

            e.Graphics.DrawString("Thank you for your purchase!", font, brush, startX, startY);
        }


        private void button2_Click(object sender, EventArgs e) //open card form
        {
            Form f1 = new SwipeCard();
            f1.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form f2 = new QrPayment();                                                                                                             
            f2.Show();
        }
    }
}
