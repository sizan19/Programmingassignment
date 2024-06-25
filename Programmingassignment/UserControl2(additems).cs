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
    public partial class UserControl2_additems_ : UserControl
    {
        function fn = new function();
        string query;
        public UserControl2_additems_()
        {
            InitializeComponent();
        }

        private void additemSubmit_Click(object sender, EventArgs e)
        {
            query = "insert into items (item_name,item_price) values ('" + textItemName.Text + "','" + textItemPrice.Text + "')";
            fn.SetData(query);
            ClearAll();

        }

        public void ClearAll()
        {
            textItemName.Clear();
            textItemPrice.Clear();


        }

        private void UserControl2_additems__Leave(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}
