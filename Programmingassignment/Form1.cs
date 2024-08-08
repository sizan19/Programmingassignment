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

        private void button1_Click(object sender, EventArgs e)
        {

            query = "SELECT * FROM LoginTable WHERE username = '" + textBox1.Text + "' AND password = '" + textBox2.Text + "'";
            DataSet ds = fn.GetData(query);
            Console.WriteLine(ds);
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string role = ds.Tables[0].Rows[0]["roles"].ToString().Trim(); // Trim the role text

                    //Console.WriteLine("Role: " + role); 

                    Form f2 = new FormHomePage(role);
                    f2.Show();
                    string discordMessage = $"{role} {textBox1.Text} logged into the system.";
                }
                else
                {
                    MessageBox.Show("You are not granted access.");
                }
            }
        }
    }
}
