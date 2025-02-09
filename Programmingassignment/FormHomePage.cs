﻿using System;
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
        private string userRole;

        public FormHomePage(string role)
        {
            InitializeComponent();
            userRole = role;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            manageUC1.Visible = true;
            manageUC1.BringToFront();
        }

        private void FormHomePage_Load(object sender, EventArgs e)
        {
            manageUC1.Visible = false;
            userControl3billing1.Visible = false;
            if (userRole == "admin")
            {
                button3.Visible = true;
            }
            else
            {
                button3.Visible = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            userControl3billing1.Visible = true;
            userControl3billing1.BringToFront();
        }
    }
}
