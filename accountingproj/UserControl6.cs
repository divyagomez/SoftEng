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
    public partial class UserControl6 : UserControl
    {

        public static UserControl6 _instance;

        public static UserControl6 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl6();
                return _instance;
            }
        }
        public UserControl6()
        {
            InitializeComponent();
        }

        private void UserControl6_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
