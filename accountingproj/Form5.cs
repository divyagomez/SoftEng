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
    public partial class Form5 : Form
    {

        public Form2 secondform;

        MySqlConnection conn;
        MySqlDataAdapter adp;
        DataTable dt;

        
        public Form5()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=accounting;Uid=root; Pwd=root;");
        }

        private void loadAll()
        {
            string query = "SELECT * from patient";

            conn.Open();
            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["patient_id"].Visible = false;
            dataGridView1.Columns["patient_fname"].HeaderText = "Firstname";
            dataGridView1.Columns["patient_lname"].HeaderText = "Lastname";
            dataGridView1.Columns["patient_bdate"].HeaderText = "Birthate";
            dataGridView1.Columns["patient_status"].HeaderText = "Year Started";
            dataGridView1.Columns["patient_num"].HeaderText = "Contact Number";

            dataGridView1.Sort(dataGridView1.Columns[1], ListSortDirection.Ascending);

        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            loadAll();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            label2.Text = dataGridView1.Rows[e.RowIndex].Cells["patient_id"].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["patient_fname"].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["patient_lname"].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["patient_num"].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["patient_status"].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells["patient_bdate"].Value.ToString());

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                button2.Enabled = false;

            }
        }

        public void button2_Click(object sender, EventArgs e)
        {
            
                if (textBox2.Text == " " || textBox3.Text == " " || textBox4.Text == " " || comboBox1.Text == " ")
                {
                    MessageBox.Show("Please input required fields.");
                }
                else
                {
                    String query6 = "INSERT INTO patient (patient_fname, patient_lname, patient_bdate, patient_num, patient_status) " +
                                   "VALUES('" + textBox2.Text + "', '" + textBox3.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + textBox4.Text + "', '" + comboBox1.Text + "')";

                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query6, conn);


                    comm.ExecuteNonQuery();
                    conn.Close();
                    loadAll();

                }            }


        public void button3_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == " " || textBox3.Text == " ")
            {
                MessageBox.Show("Please input required fields.");
            }

            else
            {
                String query7 = "Update patient set patient_fname='" + textBox2.Text + "', patient_lname='" + textBox3.Text + "', patient_bdate='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', patient_num = '" + textBox4.Text + "', patient_status='" + comboBox1.Text + "' where patient_id = '" + label2.Text + "'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(query7, conn);

                comm.ExecuteNonQuery();
                conn.Close();
                loadAll();
            }
        }
  



    private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }


        void clear()
        {
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
            comboBox1.Text = " ";

            textBox2.Focus();

            button2.Enabled = true;

           
   
        }




        private void button4_Click(object sender, EventArgs e)
        {
            

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "First Name")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            adp = new MySqlDataAdapter("SELECT * FROM patient WHERE patient_fname like '" + textBox1.Text + "%' OR patient_lname like '" + textBox1.Text + "%' OR patient_bdate like '" + textBox1.Text + "%' OR patient_num like '" + textBox1.Text + "%' OR patient_status like '" + textBox1.Text + "%'", conn);
            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "First Name";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Last Name")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Last Name";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Contact Number")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Contact Number";
                textBox4.ForeColor = Color.Gray;
            }
        }

        private void comboBox1_Enter(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Year Started")
            {
                comboBox1.Text = "";
                comboBox1.ForeColor = Color.Black;
            }
        }

        private void comboBox1_Leave(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                comboBox1.Text = "Year Started";
                comboBox1.ForeColor = Color.Gray;
            }
        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            secondform.Show();
        }

       
        

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            clear();
            loadAll();
        }

       

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            conn.Open();
            adp = new MySqlDataAdapter("SELECT * FROM patient WHERE patient_fname like '" + textBox1.Text + "%' OR patient_lname like '" + textBox1.Text + "%' OR patient_bdate like '" + textBox1.Text + "%' OR patient_num like '" + textBox1.Text + "%' OR patient_status like '" + textBox1.Text + "%'", conn);
            dt = new DataTable();
            adp.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void Form5_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            secondform.Show();
        }
    }
    }

