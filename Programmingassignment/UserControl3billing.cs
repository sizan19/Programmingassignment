using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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


   

        //Adding Items from above quantity row to the bill grid

        private decimal total = 0;

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
                total = total + currentItemTotal;

                // Update the label with the formatted total amount
                labelTotalAmount.Text = "Rs. " + total.ToString("0.00");
            }
            else
            {
                // Show an error message if the total value is invalid
                MessageBox.Show("Invalid total value. Please enter a valid decimal number.");
            }
        }
    }
}
