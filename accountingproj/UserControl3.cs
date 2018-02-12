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
    public partial class UserControl3 : UserControl
    {

        MySqlConnection conn;

        public UserControl2 second;

            public static UserControl3 _instance;

            public static UserControl3 Instance
            {
                get
                {
                    if (_instance == null)
                        _instance = new UserControl3();
                    return _instance;
                }
            }
            public UserControl3()
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
            metroTextBox1.Text = " ";
            metroTextBox2.Text = " ";
            metroTextBox3.Text = " ";
            maskedTextBox1.Text = " ";
            textBox1.Text = " ";

            metroTextBox2.Focus();

            //button2.Enabled = true;



        }





        private void UserControl3_Load(object sender, EventArgs e)
        {
            
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(button1.Text == "Add Item")
            {
                string query = "INSERT INTO items(item_name, description, price, stock)" +
                    "VALUES('" + metroTextBox2.Text + "','" + metroTextBox3.Text + "','" + maskedTextBox1.Text + "','" + textBox1.Text + "')";

                conn.Open();

                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                loadAll();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            clear();
            loadAll();
        }
    }
}
