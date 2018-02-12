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
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        MySqlConnection conn;

        public Form1()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=system;Uid=root; Pwd=root;");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if(textBox1.Text=="Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string query = "SELECT * FROM users WHERE username = '" + username + "' AND password = '" + password + "'";

            conn.Open(); //open MySql connection
            MySqlCommand comm = new MySqlCommand(query, conn); 
            MySqlDataAdapter adp = new MySqlDataAdapter(comm); 
            conn.Close(); 
            DataTable dt = new DataTable(); 
            adp.Fill(dt); 
             if (dt.Rows.Count == 1) 
            {
                string firstname = dt.Rows[0]["firstname"].ToString(); 
                string lastname = dt.Rows[0][2].ToString();
                string user_type = dt.Rows[0][3].ToString();

                int id = (int)dt.Rows[0]["user_id"];



                MessageBox.Show("Welcome " + firstname + " " + lastname);
               


                Form2 secondform = new Form2();
                secondform.id = id;
                secondform.previousform = this;
                secondform.getfirstname = firstname;
                secondform.getusertype = user_type;
                secondform.Show();
                this.Hide();

               
                
            }    

            else
            {
                    MessageBox.Show("Wrong information!", "Index", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
