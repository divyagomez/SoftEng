using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace accountingproj
{
    public partial class StockForm : Form
    {

        public Form1 previousform;
        public Form2 secondform;
        public ServiceForm serviceform;
        public AppointmentForm appointmentform;
        public StockForm stockform;

        MySqlConnection conn;

        public StockForm()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=system;Uid=root; Pwd=root;");
        }

        private void StockForm_Load(object sender, EventArgs e)
        {

        }
    }
}
