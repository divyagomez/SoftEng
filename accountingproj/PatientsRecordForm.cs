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
    public partial class PatientsRecordForm : Form
    {

        public Form1 previousform;
        public Form2 secondform;
        public ServiceForm serviceform;
        public AppointmentForm appointmentform;
        public StockForm stockform;
        public ItemForm itemform;
        public PurchaseOrderForm purchaseorderform;

        MySqlConnection conn;

        public PatientsRecordForm()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=system;Uid=root; Pwd=root;");
        }

        private void PatientsRecordForm_Load(object sender, EventArgs e)
        {

        }
    }
}
