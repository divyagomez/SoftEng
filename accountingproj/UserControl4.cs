using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace accountingproj
{
    public partial class UserControl4 : UserControl
    {

        MySqlConnection conn;

        public UserControl2 second;

        public static UserControl4 _instance;

        public static UserControl4 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl4();
                return _instance;
            }
        }
        public UserControl4()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=accounting;Uid=root; Pwd=root;");
        }


        private void loadAll()
        {
            string query = "SELECT * from items";

            conn.Open();
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            metroGrid1.DataSource = dt;
            metroGrid1.Columns["item_code"].HeaderText = "Item Code";
            metroGrid1.Columns["item_name"].HeaderText = "Item Name";
            metroGrid1.Columns["description"].HeaderText = "Description";
            metroGrid1.Columns["price"].HeaderText = "Price";
            //metroGrid1.Columns["patient_status"].HeaderText = "Year Started";
            //metroGrid1.Columns["patient_num"].HeaderText = "Contact Number";

            metroGrid1.Sort(metroGrid1.Columns[1], ListSortDirection.Ascending);

        }


        void clear()
        {
            metroTextBox5.Text = " ";
            metroTextBox2.Text = " ";
            metroTextBox1.Text = " ";
            metroComboBox1.Text = " ";


            metroTextBox5.Focus();

            //button2.Enabled = true;



        }






        private void UserControl4_Load(object sender, EventArgs e)
        {

        }

        private void metroTextBox3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
