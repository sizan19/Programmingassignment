using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Programmingassignment
{
    public partial class Form1 : Form
    {
        string sqlstr = "";

        SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\sizan\\Desktop\\sizan is studying\\assignement\\Programmingassignment\\database\\programmingpos.mdf;Integrated Security=True;Connect Timeout=30");

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
            sqlstr = "SELECT * FROM LoginTable WHERE username = @username AND password = @password";
            conn.Open();
            using (SqlCommand cmd1 = new SqlCommand(sqlstr, conn))
            {
                cmd1.Parameters.AddWithValue("@username", textBox1.Text);
                cmd1.Parameters.AddWithValue("@password", textBox2.Text);

                SqlDataReader dr1 = cmd1.ExecuteReader();
                if (dr1.Read())
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
            conn.Close();
        }
    }
}
