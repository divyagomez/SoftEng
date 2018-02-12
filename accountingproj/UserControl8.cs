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
    public partial class UserControl8 : UserControl
    {

        public static UserControl8 _instance;

        public static UserControl8 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl8();
                return _instance;
            }
        }
        public UserControl8()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void UserControl8_Load(object sender, EventArgs e)
        {

        }
    }
}
