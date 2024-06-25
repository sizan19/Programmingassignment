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
    public partial class FormHomePage : Form
    {
        public FormHomePage()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            userControl2_additems_1.Visible = true;
            userControl2_additems_1.BringToFront();


        }

        private void FormHomePage_Load(object sender, EventArgs e)
        {
            userControl2_additems_1.Visible = false;
            userControl3billing1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControl3billing1.Visible = true;
            userControl3billing1.BringToFront();
        }
    }
}
