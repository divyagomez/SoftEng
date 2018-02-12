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
    public partial class Form6 : Form
    {
        public Form2 secondform;

        MySqlConnection conn;

        public Form6()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=accounting;Uid=root; Pwd=root;");
        }

        private void loadAll()
        {

            string app = "SELECT * from appointment_line WHERE appline_status = 'Ongoing'";


            conn.Open();
            MySqlCommand com = new MySqlCommand(app, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;
            dataGridView1.Columns["appline_id"].Visible = false;
            dataGridView1.Columns["appline_name"].Visible = false;
            dataGridView1.Columns["appline_date"].HeaderText = "Appointment Date";
            dataGridView1.Columns["appline_starttime"].HeaderText = "Start Time";
            dataGridView1.Columns["appline_endtime"].HeaderText = "End Time";
            dataGridView1.Columns["appline_status"].Visible = false;
            dataGridView1.Columns["treatment"].Visible = false;

            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);

        }



        private void Form6_Load(object sender, EventArgs e)
        {
            loadAll();
            button9.Enabled = true;

            label11.Text = this.getid;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == " ")
            {
                string select = "SELECT * FROM patient WHERE patient_fname LIKE " + "'%" + textBox5.Text + "%' || patient_lname LIKE " + "'%" + textBox5.Text + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(select, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView2.DataSource = dt;

                this.panel1.Show();
                

                dataGridView2.Columns["patient_id"].Visible = false;
                dataGridView2.Columns["patient_bdate"].Visible = false;
                dataGridView2.Columns["patient_num"].Visible = false;
                dataGridView2.Columns["patient_status"].Visible = false;
                dataGridView2.Columns["patient_fname"].HeaderText = "First Name";
                dataGridView2.Columns["patient_lname"].HeaderText = "Last Name";
               
            }
            else
            {
                string select = "SELECT * FROM patient WHERE patient_fname LIKE " + "'%" + textBox5.Text + "%' || patient_lname LIKE " + "'%" + textBox5.Text + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(select, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView2.DataSource = dt;

                if (dt.Rows.Count != 0)
                {
                    this.panel1.Show();

                    dataGridView2.Columns["patient_id"].Visible = false;
                    dataGridView2.Columns["patient_bdate"].Visible = false;
                    dataGridView2.Columns["patient_num"].Visible = false;
                    dataGridView2.Columns["patient_status"].Visible = false;
                    dataGridView2.Columns["patient_fname"].HeaderText = "First Name";
                    dataGridView2.Columns["patient_lname"].HeaderText = "Last Name";

                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
         
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string selected_fn;
            string selected_ln;

            selected_fn = dataGridView2.Rows[e.RowIndex].Cells["patient_fname"].Value.ToString();
            selected_ln = dataGridView2.Rows[e.RowIndex].Cells["patient_lname"].Value.ToString();

            textBox5.Text = selected_fn + " " + selected_ln;
            this.panel1.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
            panel2.Show();

            string select = "SELECT * FROM patient";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(select, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView3.DataSource = dt;



            dataGridView3.Columns["patient_id"].Visible = false;
            dataGridView3.Columns["patient_bdate"].Visible = false;
            dataGridView3.Columns["patient_num"].Visible = false;
            dataGridView3.Columns["patient_status"].Visible = false;
            dataGridView3.Columns["patient_fname"].HeaderText = "First Name";
            dataGridView3.Columns["patient_lname"].HeaderText = "Last Name";






            maskedTextBox1.Hide();
            maskedTextBox2.Hide();
            panel3.Hide();
            



        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            panel2.Hide();
            maskedTextBox1.Show();
            maskedTextBox2.Show();
            button9.Enabled = true;
           





        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == " " || maskedTextBox1.Text == " " || maskedTextBox2.Text == " ")

            {
                MessageBox.Show("Please input required fields.");
            }
            else
            {
                
                String name = textBox5.Text;
                String starttime = maskedTextBox1.Text;
                String endtime = maskedTextBox2.Text;
                String date = dateTimePicker1.Value.ToString("yyyy-DD-mm");

                String query = "SELECT * FROM appointment_line WHERE appline_date = '" + date + "' AND appline_starttime = '" + starttime + "' AND appline_endtime = '" + endtime + "'";
                conn.Open();



                MySqlCommand com = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(com);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                com.ExecuteNonQuery();
                conn.Close();

                if (dt.Rows.Count > 0)
                {

                    MessageBox.Show("Schedule Already Taken!");
                }
                else
                {


                    String query3 = "INSERT INTO appointment_line(appline_name, appline_date, appline_starttime, appline_endtime, appline_status, treatment) " +
                                   "VALUES('" + textBox5.Text + "', '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', '" + maskedTextBox1.Text + "', '" + maskedTextBox2.Text + "', '" + "Ongoing" + "', '" + comboBox1.Text + "')";

                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query3, conn);


                    comm.ExecuteNonQuery();
                    conn.Close();
                    loadAll();

                }

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            label6.Text = dataGridView1.Rows[e.RowIndex].Cells["appline_id"].Value.ToString();
            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["appline_name"].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells["appline_date"].Value.ToString());
            maskedTextBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["appline_starttime"].Value.ToString();
            maskedTextBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["appline_endtime"].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["treatment"].Value.ToString();

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                button1.Enabled = false;

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.MinDate = DateTime.Now;

           /* if (dateTimePicker1.Value > dateTimePicker1.MinDate)
            {

                String bye = "Update appointment_line SET appline_status = '" + "Finished" + "' WHERE appline_id = '" + label6.Text + "'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(bye, conn);


            
                comm.ExecuteNonQuery();
                conn.Close();
                loadAll();

            }*/


        }

        private void Form6_Load_1(object sender, EventArgs e)
        {

            button9.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == " " || maskedTextBox1.Text == " " || maskedTextBox2.Text == " ")

            {
                MessageBox.Show("Please input required fields.");
            }

            else
            {
                    String name = textBox5.Text;
                    String starttime = maskedTextBox1.Text;
                    String endtime = maskedTextBox2.Text;
                    String date = dateTimePicker1.Value.ToString("yyyy-DD-mm");


                    String query = "SELECT * FROM appointment_line WHERE appline_date ='" + date + "' AND appline_starttime ='" + starttime + "' AND appline_endtime = '" + endtime + "'";
                    conn.Open();

                    MySqlCommand com = new MySqlCommand(query, conn);
                    MySqlDataAdapter adp = new MySqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    com.ExecuteNonQuery();
                    conn.Close();
                    
                    if (dt.Rows.Count > 0)
                    {

                        MessageBox.Show("Schedule Already Taken!");
                    }
                    else
                    {


                    String query4 = "Update appointment_line SET appline_name = '" + textBox5.Text + "', appline_date = '" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "', appline_starttime = '" + maskedTextBox1.Text + "', appline_endtime = '" + maskedTextBox2.Text + "', treatment = '" + comboBox1.Text + "'  WHERE appline_id = '" + label6.Text + "'";


                    conn.Open();
                    MySqlCommand comm = new MySqlCommand(query4, conn);


                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Details Successfully Changed!");
                    loadAll();
                }


            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("So, Do You Wish To Cancel?", "Cancel", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {


                String bye = "Update appointment_line SET appline_starttime = '" + " " + "' , appline_endtime = '" + " " + "' , appline_status = '" + "Cancelled" + "'  WHERE appline_id = '" + label6.Text + "'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(bye, conn);


                comm.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Schedule successfully cancelled!");
                loadAll();

            }


        }

        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
            secondform.Show();
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            loadAll();
        }


        void clear()
        {
            textBox5.Text = "";
            maskedTextBox1.Text = "";
            maskedTextBox2.Text = "";
            comboBox1.Text = "";
           

            textBox5.Focus();

            button1.Enabled = true;



        }



        private void button5_Click(object sender, EventArgs e)
        {
            clear();
            loadAll();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox5.Text == " ")
            {
                string select = "SELECT * FROM patient WHERE patient_fname LIKE " + "'%" + textBox1.Text + "%' || patient_lname LIKE " + "'%" + textBox1.Text + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(select, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView3.DataSource = dt;

               

                dataGridView3.Columns["patient_id"].Visible = false;
                dataGridView3.Columns["patient_bdate"].Visible = false;
                dataGridView3.Columns["patient_num"].Visible = false;
                dataGridView3.Columns["patient_status"].Visible = false;
                dataGridView3.Columns["patient_fname"].HeaderText = "First Name";
                dataGridView3.Columns["patient_lname"].HeaderText = "Last Name";
            }
            else
            {
                string select = "SELECT * FROM patient WHERE patient_fname LIKE " + "'%" + textBox1.Text + "%' || patient_lname LIKE " + "'%" + textBox1.Text + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(select, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView3.DataSource = dt;

                if (dt.Rows.Count != 0)
                {
                    //this.panel1.Show();

                    dataGridView3.Columns["patient_id"].Visible = false;
                    dataGridView3.Columns["patient_bdate"].Visible = false;
                    dataGridView3.Columns["patient_num"].Visible = false;
                    dataGridView3.Columns["patient_status"].Visible = false;
                    dataGridView3.Columns["patient_fname"].HeaderText = "First Name";
                    dataGridView3.Columns["patient_lname"].HeaderText = "Last Name";
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string selected_fn;
            string selected_ln;
            string fullname;
           



            selected_fn = dataGridView3.Rows[e.RowIndex].Cells["patient_fname"].Value.ToString();
            selected_ln = dataGridView3.Rows[e.RowIndex].Cells["patient_lname"].Value.ToString();


            fullname = selected_fn + " " + selected_ln;

            label11.Text = fullname;



            

            String query = "SELECT * FROM appointment_line WHERE appline_name ='" + fullname +"'";
            conn.Open();

            MySqlCommand com = new MySqlCommand(query, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();

            
         

            dataGridView4.DataSource = dt;
            dataGridView4.Columns["appline_id"].Visible = false;
            dataGridView4.Columns["appline_name"].Visible = false;
            dataGridView4.Columns["appline_date"].HeaderText = "Appointment Date";
            dataGridView4.Columns["appline_starttime"].Visible = false;
            dataGridView4.Columns["appline_endtime"].Visible = false;
            dataGridView4.Columns["appline_status"].HeaderText = "Status";
            dataGridView4.Columns["treatment"].Visible = false;





        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string date;
            string status;
            string id;

            id = dataGridView4.Rows[e.RowIndex].Cells["appline_id"].Value.ToString();
            date = dataGridView4.Rows[e.RowIndex].Cells["appline_date"].Value.ToString();
            status = dataGridView4.Rows[e.RowIndex].Cells["appline_status"].Value.ToString();

            String query1 = "SELECT * FROM appointment_line WHERE appline_id = '" + id + "'";
            conn.Open();

            MySqlCommand com = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();

            dataGridView5.DataSource = dt;
            dataGridView5.Columns["appline_id"].Visible = false;
            dataGridView5.Columns["appline_name"].Visible = false;
            dataGridView5.Columns["appline_date"].Visible = false;
            dataGridView5.Columns["appline_starttime"].HeaderText = "Start Time";
            dataGridView5.Columns["appline_endtime"].HeaderText = "End Time";
            dataGridView5.Columns["appline_status"].Visible = false;
            dataGridView5.Columns["treatment"].HeaderText = "Treatment";
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            panel3.Show();

            string select = "SELECT * FROM appointment_line";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(select, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView3.DataSource = dt;

            


            dataGridView6.DataSource = dt;
            dataGridView6.Columns["appline_id"].Visible = false;
            dataGridView6.Columns["appline_name"].Visible = false;
            dataGridView6.Columns["appline_date"].HeaderText = "Appointment Date";
            dataGridView6.Columns["appline_starttime"].Visible = false;
            dataGridView6.Columns["appline_endtime"].Visible = false;
            dataGridView6.Columns["appline_status"].HeaderText = "Appointment Status";
            dataGridView6.Columns["treatment"].Visible = false;


            dataGridView6.Sort(dataGridView6.Columns[2], ListSortDirection.Ascending);

            button6.Enabled = true;
        }

        public void dataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            string date;
            string status;
            string id;
        
            id = dataGridView6.Rows[e.RowIndex].Cells["appline_id"].Value.ToString();
            date = dataGridView6.Rows[e.RowIndex].Cells["appline_date"].Value.ToString();
            status = dataGridView6.Rows[e.RowIndex].Cells["appline_status"].Value.ToString();

            String query1 = "SELECT * FROM appointment_line WHERE appline_id = '" + id + "'";
            conn.Open();

            MySqlCommand com = new MySqlCommand(query1, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();

            dataGridView7.DataSource = dt;
            dataGridView7.Columns["appline_id"].Visible = false;
            dataGridView7.Columns["appline_name"].HeaderText = "Name";
            dataGridView7.Columns["appline_date"].Visible = false;
            dataGridView7.Columns["appline_starttime"].HeaderText = "Start Time";
            dataGridView7.Columns["appline_endtime"].HeaderText = "End Time";
            dataGridView7.Columns["appline_status"].Visible = false;
            dataGridView7.Columns["treatment"].HeaderText = "Treatment";


        }




        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)

        {

            var a = dateTimePicker2.Value.ToString("yyyy-MM-dd");
            var b = dateTimePicker3.Value.ToString("yyyy-MM-dd");


            string name = label11.Text;


            String query2 = "SELECT * FROM appointment_line WHERE appline_date BETWEEN '" + a + "' AND '" + b + "' AND appline_name = '" + name + "'";
            conn.Open();

            MySqlCommand com = new MySqlCommand(query2, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();


            dataGridView4.DataSource = dt;
            dataGridView4.Columns["appline_id"].Visible = false;
            dataGridView4.Columns["appline_name"].Visible = false;
            dataGridView4.Columns["appline_date"].HeaderText = "Date";
            dataGridView4.Columns["appline_starttime"].Visible = false;
            dataGridView4.Columns["appline_endtime"].Visible = false;
            dataGridView4.Columns["appline_status"].HeaderText = "Status";
            dataGridView4.Columns["treatment"].Visible = false;


            dataGridView5.DataSource = dt;
            dataGridView5.Columns["appline_id"].Visible = false;
            dataGridView5.Columns["appline_name"].Visible = false;
            dataGridView5.Columns["appline_date"].Visible = false;
            dataGridView5.Columns["appline_starttime"].HeaderText = "Start Time";
            dataGridView5.Columns["appline_endtime"].HeaderText = "End Time";
            dataGridView5.Columns["appline_status"].Visible = false;
            dataGridView5.Columns["treatment"].HeaderText = "Treatment";
        }

        public string getid { get; set; }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            var a = dateTimePicker4.Value.ToString("yyyy-MM-dd");
            var b = dateTimePicker5.Value.ToString("yyyy-MM-dd");


            //dateTimePicker5.MinDate = dateTimePicker4.Value;



            String query2 = "SELECT * FROM appointment_line WHERE appline_date BETWEEN '" + a + "' AND '" + b + "'";
            conn.Open();

            MySqlCommand com = new MySqlCommand(query2, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();


            dataGridView6.DataSource = dt;
            dataGridView6.Columns["appline_id"].Visible = false;
            dataGridView6.Columns["appline_name"].Visible = false;
            dataGridView6.Columns["appline_date"].HeaderText = "Date";
            dataGridView6.Columns["appline_starttime"].Visible = false;
            dataGridView6.Columns["appline_endtime"].Visible = false;
            dataGridView6.Columns["appline_status"].HeaderText = "Status";
            dataGridView6.Columns["treatment"].Visible = false;


            dataGridView7.DataSource = dt;
            dataGridView7.Columns["appline_id"].Visible = false;
            dataGridView7.Columns["appline_name"].HeaderText = "Name";
            dataGridView7.Columns["appline_date"].Visible = false;
            dataGridView7.Columns["appline_starttime"].HeaderText = "Start Time";
            dataGridView7.Columns["appline_endtime"].HeaderText = "End Time";
            dataGridView7.Columns["appline_status"].Visible = false;
            dataGridView7.Columns["treatment"].HeaderText = "Treatment";
        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker5.MinDate = dateTimePicker4.Value;
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.MinDate = dateTimePicker2.Value;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == " ")
            {
                string select = "SELECT * FROM appointment_line WHERE appline_status LIKE " + "'%" + textBox2.Text + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(select, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView3.DataSource = dt;



                dataGridView6.Columns["appline_id"].Visible = false;
                dataGridView6.Columns["appline_name"].Visible = false;
                dataGridView6.Columns["appline_date"].Visible = false;
                dataGridView6.Columns["appline_starttime"].Visible = false;
                dataGridView6.Columns["appline_endtime"].Visible = false;
                dataGridView6.Columns["appline_status"].HeaderText = "Status";
                dataGridView6.Columns["treatment"].Visible = false;



            }
            else
            {
                string select = "SELECT * FROM appointment_line WHERE appline_status LIKE " + "'%" + textBox2.Text + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(select, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView3.DataSource = dt;

                if (dt.Rows.Count != 0)
                {
                    //this.panel1.Show();

                    dataGridView6.Columns["appline_id"].Visible = false;
                    dataGridView6.Columns["appline_name"].Visible = false;
                    dataGridView6.Columns["appline_date"].Visible = false;
                    dataGridView6.Columns["appline_starttime"].Visible = false;
                    dataGridView6.Columns["appline_endtime"].Visible = false;
                    dataGridView6.Columns["appline_status"].HeaderText = "Status";
                    dataGridView6.Columns["treatment"].Visible = false;
                }
            }
        }
    }
}
