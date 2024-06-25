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
    public partial class UserControlWelcome : UserControl
    {
        public UserControlWelcome()
        {
            InitializeComponent();
        }

        int num = 0;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (num == 0)
            {
                LabelBanner.Location = new Point(263, 448);
                LabelBanner.ForeColor = Color.Orange;
                num++;
            }
            else if (num == 1)
            {
                LabelBanner.Location = new Point(197, 71);
                LabelBanner.ForeColor = Color.Green;
                num++;
            }
            else if (num == 2)
            {
                LabelBanner.Location = new Point(589, 453);
                LabelBanner.ForeColor = Color.Blue;
                num = 0;
            }

        }
        private void UserControlWelcome_Load_1(object sender, EventArgs e)
        {
            timer1.Start();


        }
    }
}
