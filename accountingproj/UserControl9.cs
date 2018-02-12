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
    public partial class UserControl9 : UserControl
    {

        public static UserControl9 _instance;

        public static UserControl9 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl9();
                return _instance;
            }
        }
        public UserControl9()
        {
            InitializeComponent();
        }

        private void UserControl9_Load(object sender, EventArgs e)
        {

        }
    }
}
