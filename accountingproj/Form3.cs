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
    public partial class Form3 : Form
    {
        public Form2 secondform;




        MySqlConnection conn;
        MySqlDataAdapter adp;
        DataTable dt;

        public Form3()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=accounting;Uid=root; Pwd=root;");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label2.Text = dataGridView1.Rows[e.RowIndex].Cells["user_id"].Value.ToString();
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["firstname"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["lastname"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["username"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["password"].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["user_type"].Value.ToString();



            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                button1.Enabled = false;

            }




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " " || textBox2.Text == " " || comboBox1.Text == " " || textBox3.Text == " " || textBox4.Text == " ")
              
            {
                MessageBox.Show("Please input required fields.");
            }
            else
            {


                String username = textBox3.Text;
                String query = "SELECT *FROM users WHERE username ='" + username + "'";
                conn.Open();

                MySqlCommand com = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                    MessageBox.Show("Username Already Taken!");
                }
                else
                {


                    String query3 = "INSERT INTO users(firstname, lastname, user_type, username, password) " +
                                   "VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + comboBox1.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "')";

                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query3, conn);


                    comm.ExecuteNonQuery();
                    conn.Close();
                    loadAll();

                }
                
            }
        }


    
    private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            loadAll();

           


        }
        private void loadAll()
        {
            string query = "SELECT * from users";

            conn.Open(); 
            MySqlCommand com = new MySqlCommand(query, conn); 
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            conn.Close(); 
            DataTable dt = new DataTable(); 
            adp.Fill(dt); 

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["user_id"].Visible = false;
            dataGridView1.Columns["password"].Visible = false;
            dataGridView1.Columns["firstname"].HeaderText = "Firstname";
            dataGridView1.Columns["lastname"].HeaderText = "Lastname";
            dataGridView1.Columns["username"].HeaderText = "Username";
            dataGridView1.Columns["user_type"].HeaderText = "Role";

            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

        }


       

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " " || textBox2.Text == " ")
            {
                MessageBox.Show("Please input required fields.");
            }
            else
            {
                String username = textBox3.Text;
                String query5 = "SELECT *FROM users WHERE username ='" + username + "'";
                conn.Open();

                MySqlCommand com = new MySqlCommand(query5, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                conn.Close();


                if (dt.Rows.Count > 0)
                {

                    MessageBox.Show("Username Already Taken!");
                }
                else
                {


                    String query4 = "Update users set firstname='" + textBox1.Text + "', lastname='" + textBox2.Text + "', user_type = '" + comboBox1.Text + "', username = '" + textBox3.Text + "', password = '" + textBox4.Text + "' where user_id = '" + label2.Text + "'";


                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query4, conn);

                  
                    comm.ExecuteNonQuery();
                    conn.Close();
                    loadAll();    
                }
       
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }


        void clear()
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            comboBox1.Text = " ";

            textBox1.Focus();

            button1.Enabled = true;

        }


        private void button3_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "First Name")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "First Name";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Last Name")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Last Name";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Role")
            {
                comboBox1.Text = "";
                comboBox1.ForeColor = Color.Black;
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = "Role";
                comboBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Username")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Username";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Password")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Password";
                textBox4.ForeColor = Color.Gray;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
           
            conn.Open();
            adp = new MySqlDataAdapter("SELECT * FROM users WHERE firstname like '" + textBox5.Text + "%' OR lastname like '" + textBox5.Text + "%' OR user_type like '" + textBox5.Text + "%' OR username like '" + textBox5.Text + "%'", conn);
            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            secondform.Show();
        }
    }
}

