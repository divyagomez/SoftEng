using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace accountingproj
{
    public partial class UserControl5 : UserControl
    {
        public static UserControl5 _instance;

        public static UserControl5 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl5();
                return _instance;
            }
        }
        public UserControl5()
        {
            InitializeComponent();
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {
            dataGridView1.Hide();
            panel2.Hide();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            dataGridView1.Show();
        }

        private void metroButton1_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Show();
        }
    }
}
