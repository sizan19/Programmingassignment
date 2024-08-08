using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Programmingassignment
{
    public partial class ManageUC : UserControl
    {
        function fn = new function();
        string query;
        public ManageUC()
        {
            InitializeComponent();
        }

        public void ClearAll()
        {
            textBox2.Clear();
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e) // Add Item
        {
            query = "insert into items (item_name,item_price) values ('" + textBox2.Text + "','" + textBox1.Text + "')";
            fn.SetData(query);
            ClearAll();
        }

        private void button5_Click(object sender, EventArgs e) // Update Item
        {
            query = "update items set item_price = '" + textBox1.Text + "' where item_name = " + textBox2.Text + "";
            fn.SetData(query);
            ClearAll();
        }

        private void button6_Click(object sender, EventArgs e)// Delete Item
        {
            if (MessageBox.Show("Data will be deleted. Are you sure?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                query = "delete from items where item_name = " + textBox2.Text + "";
                fn.SetData(query);
                ClearAll();
            }
        }



        private void tabPage1_Enter(object sender, EventArgs e)
        {
            dataGridView2.AutoGenerateColumns = false;

            // Clear existing columns
            dataGridView2.Columns.Clear();

            // Define your custom columns
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn { Name = "name", HeaderText = "Name", DataPropertyName = "item_name" });
            dataGridView2.Columns.Add(new DataGridViewTextBoxColumn { Name = "price", HeaderText = "Price", DataPropertyName = "item_price" });
            // Load data from the database
            string query = "select * from Items";
            DataSet ds = fn.GetData(query);

            // Set the data source
            dataGridView2.DataSource = ds.Tables[0];
        }


        private void tabPage2_Enter(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;

            // Clear existing columns
            dataGridView1.Columns.Clear();

            // Define your custom columns
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Username", HeaderText = "Name", DataPropertyName = "username" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Password", HeaderText = "Price", DataPropertyName = "password" });
            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn { Name = "Roles", HeaderText = "Roles", DataPropertyName = "roles" });

            // Load data from the database
            string query = "select * from LoginTable";
            DataSet ds = fn.GetData(query);

            // Set the data source
            dataGridView1.DataSource = ds.Tables[0];

        }

        public void ClearAllUserPage()
        {
            textBox4.Clear();
            textBox3.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox4.Text.Trim();
            string password = textBox3.Text.Trim();
            string selectedValue = comboBox1.SelectedItem.ToString();

            string query = "insert into LoginTable (username, password, roles) values ('" + username + "','" + password + "','" + selectedValue + "')";
            fn.SetData(query);
            ClearAllUserPage();
        }

        private void button3_Click(object sender, EventArgs e) // edit login
        {
            string username = textBox4.Text.Trim();
            string password = textBox3.Text.Trim();
            string selectedValue = comboBox1.SelectedItem.ToString();

            string query = "update LoginTable set password = '" + password + "', roles = '" + selectedValue + "' where username = '" + username + "'";
            fn.SetData(query);
            ClearAllUserPage();
        }

        private void button4_Click(object sender, EventArgs e) // delete login
        {
            string username = textBox4.Text.Trim();
            string password = textBox3.Text.Trim();
            string selectedValue = comboBox1.SelectedItem.ToString();

            string query = "delete from LoginTable where username = '" + username + "'";
            fn.SetData(query);
            ClearAllUserPage();
        }
    }
}
