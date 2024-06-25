using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programmingassignment
{
    public partial class UserControl3billing : UserControl
    {
        function fn = new function();
        string query;
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textboxItemQuantity.ResetText();
            textBoxTotal.ResetText();

            string text = listBox1.GetItemText(listBox1.SelectedItem);
            textboxItemName.Text = text;
            query = "select item_price from items where item_name = '" + text + "'";
            DataSet ds = fn.GetData(query);

            textboxItemPrice.Text = ds.Tables[0].Rows[0][0].ToString();


        }

        private void textboxItemQuantity_ValueChanged(object sender, EventArgs e)
        {
            Int64 qty = Int64.Parse(textboxItemQuantity.Value.ToString());
            Int64 price = Int64.Parse(textboxItemPrice.Text.ToString());
            textBoxTotal.Text = (qty * price).ToString();

        }
    }
}
