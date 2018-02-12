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
    public partial class UserControl10 : UserControl
    {
        public static UserControl10 _instance;



        public static UserControl10 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl10();
                return _instance;
            }
        }
        public UserControl10()
        {
            InitializeComponent();
        }

        private void UserControl10_Load(object sender, EventArgs e)
        {

        }
    }
}
