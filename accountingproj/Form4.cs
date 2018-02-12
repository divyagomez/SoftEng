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
    public partial class Form4 : Form
    {

        public Form2 secondform;




        MySqlConnection conn;
        public Form4()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=accounting;Uid=root; Pwd=root;");
        }

        public int id { get; set; }

        private void Form4_Load(object sender, EventArgs e)
        {
            label3.Text = this.id.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            if (textBox3.Text == "")
            {
                MessageBox.Show("You did not enter any username.");
            }

            else
            {

                String username = textBox3.Text;
                String query5 = "SELECT *FROM users" + " WHERE username ='" + username + "'";
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


                    String query4 = "Update users SET username = '" + textBox3.Text + "' WHERE user_id = '" + label3.Text + "'";


                }


            }
        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }






        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Change Username")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Change Username";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Old Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Old Password";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter New Password")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter New Password";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Confirm New Password")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Confirm New Password";
                textBox4.ForeColor = Color.Gray;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (textBox2.Text=="" && textBox1.Text=="" && textBox4.Text=="")
            {
                MessageBox.Show("Please input all fields.");
            }

            else
            {
                String query7 = "SELECT *FROM users" + " WHERE user_id ='" + label3.Text + "'";
                conn.Open();

                MySqlCommand com = new MySqlCommand(query7, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                conn.Close();


                string pass = dt.Rows[0]["password"].ToString();

                if (textBox2.Text != pass)
                {
                    MessageBox.Show("Old password does not match.");

                }
                
                else if (textBox1.Text != textBox4.Text)

                {

                    MessageBox.Show("The two passwords do not match.");
                }
                else
                {

                    String query8 = "Update users SET password = '" + textBox1.Text + "' WHERE user_id = '" + label3.Text + "'";


                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query8, conn);


                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Password Successfully Changed!");

                }

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form4_FormClosing(object sender, FormClosingEventArgs e)
        {
            secondform.Show();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

