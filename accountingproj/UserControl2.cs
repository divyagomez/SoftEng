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
        

        public partial class UserControl2 : UserControl
    {
        MySqlConnection conn;
       // private MySqlDataAdapter adp;
       // private DataTable dt;

        public static UserControl2 _instance;


        public Form2 secondform; 
        


        public static UserControl2 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl2();
                return _instance;
            }
        }
        public UserControl2()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=system;Uid=root; Pwd=root;");
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
            metroGrid1.Columns["item_mes"].HeaderText = "Measurement";
            metroGrid1.Columns["supplier"].HeaderText = "Supplier";
            metroGrid1.Columns["item_stock"].HeaderText = "Stock";
         

            metroGrid1.Sort(metroGrid1.Columns[1], ListSortDirection.Ascending);

        }


        void clear()
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            maskedTextBox2.Text = " ";
            comboBox4.Text = " ";
            metroTextBox6.Text = " ";
            textBox4.Text = " ";




            metroTextBox2.Focus();

            //button2.Enabled = true;



        }





        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void UserControl2_Load(object sender, EventArgs e)
        {
            metroPanel1.Hide();
            metroPanel2.Hide();
            metroPanel3.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroPanelito_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            metroPanel1.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            metroPanel1.Show();



        }

        private void metroLink1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            metroPanel3.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            metroPanel2.Hide();
        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            metroPanel2.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            metroPanel3.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(metroTextBox2.Text == "" || metroTextBox3.Text == "")
            {
                MessageBox.Show("Please input required fields.");
            }
            else
            {
                String query2  = "Update items set item_name='" + metroTextBox2.Text + "', description= '" + metroTextBox3.Text + "', item_price= '" + maskedTextBox1.Text + "', item_mes='" + comboBox3.Text + "', supplier ='" + metroTextBox5.Text + "', item_stock ='" + metroTextBox4.Text + "'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query2, conn);

                comm.ExecuteNonQuery();
                conn.Close();
                loadAll();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (metroTextBox2.Text == " " || metroTextBox3.Text == " ")
            {
                MessageBox.Show("Please input required fields.");
            }

            else
            {
                String query1 = "Delete from item where item_code = '" + metroTextBox11.Text + "'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query1, conn);

                comm.ExecuteNonQuery();
                conn.Close();
                loadAll();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear();
            loadAll();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Add Item")
            {
                string query = "INSERT INTO items(item_name, description, item_price, item_mes, supplier, item_stock)" +
                    "VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + maskedTextBox2.Text + "','" + comboBox4.Text + "','" + metroComboBox6.Text + "','" + textBox4.Text + "')";

                conn.Open();

                MySqlCommand comm = new MySqlCommand(query, conn);
                comm.ExecuteNonQuery();
                conn.Close();
                loadAll();

            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            clear();
            loadAll();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.ReadOnly = true;
            textBox1.BackColor = System.Drawing.SystemColors.InactiveCaption;
        }

        private void metroTextBox11_Click(object sender, EventArgs e)
        {
            metroTextBox11.ReadOnly = true;
            metroTextBox11.BackColor = System.Drawing.SystemColors.InactiveCaption;
        }
    }
    }

