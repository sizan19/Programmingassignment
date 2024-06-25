using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Programmingassignment
{
    public partial class Form1 : Form
    {
        function fn = new function();
        string query;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            query = "SELECT * FROM LoginTable WHERE username = '"+textBox1.Text+"' AND password = '"+textBox2.Text+"'";
            DataSet ds = fn.GetData(query);
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //this.Hide();
                    Form f2 = new FormHomePage();
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("You are not granted access.");
                }
            }
        }
    }
}
