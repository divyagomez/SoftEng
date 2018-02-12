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
    public partial class UserControl7 : UserControl
    {
        public static UserControl7 _instance;

        public static UserControl7 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl7();
                return _instance;
            }
        }

        public UserControl7()
        {
            InitializeComponent();
        }


        private void UserControl7_Load(object sender, EventArgs e)
        {
            panel1.Hide();
            panel2.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroLabel2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void metroTabPage1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel34_Click(object sender, EventArgs e)
        {

        }
    }
}
