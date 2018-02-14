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
    public partial class AppointmentForm : Form
    {

        public Form1 previousform;
        public Form2 secondform;
        public int id;
        public ServiceForm serviceform;
        public AppointmentForm appointmentform;

        MySqlConnection conn;


        public AppointmentForm()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=system;Uid=root; Pwd=root;");
        }


        private void AppointmentForm_Load(object sender, EventArgs e)
        {
            panel2.Hide();
            panel3.Hide();
            panel4.Hide();
            panel5.Hide();
            panel6.Hide();
            panel7.Hide();
            panel8.Hide();



            label3.Text = "Today: " + DateTime.Now.ToString();
            textBox1.Text = DateTime.Now.Year.ToString();
            metroDateTime1.MinDate = DateTime.Today;

            loadAll();
            loadPatients();

            string sel = "SELECT * FROM treat";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cmbTreat.Items.Add(dt.Rows[i][1].ToString());
            }
           

            metroTabControl1.SelectedTab = metroTabPage1;
        }



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panel7.Show();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel3.Show();
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            panel4.Hide();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            panel2.Hide();
            button11.Enabled = true;
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            panel3.Hide();
            button1.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "" || metroDateTime1.Text == "" || metroComboBox1.Text == "" || metroComboBox2.Text == "" || metroComboBox7.Text == "" || metroComboBox3.Text == "" || metroComboBox4.Text == "" || metroComboBox8.Text == "" || metroTextBox2.Text == "")
            {
                MessageBox.Show("Please fill up all data.", "Appointment Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string start;
                string end;
                string date = metroDateTime1.Text;

                int shour = int.Parse(metroComboBox1.Text);
                int ehour = int.Parse(metroComboBox3.Text);

                metroDateTime1.MinDate = DateTime.Today;

                if (metroComboBox7.Text == "AM")
                {
                    shour = shour + 0;
                }
                else if (metroComboBox7.Text == "PM")
                {
                    if (shour == 12)
                    {
                        shour = shour + 0;
                    }
                    else
                    {
                        shour = shour + 12;
                    }
                }
                else
                {
                    MessageBox.Show("Please select if it's in AM or PM", "Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (metroComboBox8.Text == "AM")
                {
                    ehour = ehour + 0;
                }
                else if (metroComboBox8.Text == "PM")
                {
                    if (ehour == 12)
                    {
                        ehour = ehour + 0;
                    }
                    else
                    {
                        ehour = ehour + 12;
                    }
                }
                else
                {
                    MessageBox.Show("Please select if it's in AM or PM", "Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                int sminute = int.Parse(metroComboBox2.Text);
                int eminute = int.Parse(metroComboBox4.Text);

                start = date + " " + shour + ":" + metroComboBox2.Text + ":00";
                end = date + " " + ehour + ":" + metroComboBox4.Text + ":00";

                string start_time = shour + ":" + metroComboBox2.Text + " " + metroComboBox7.Text;
                string end_time = ehour + ":" + metroComboBox4.Text + " " + metroComboBox8.Text;


                if ((shour >= 8 && ehour < 18))
                {
                    if ((shour == ehour && sminute > eminute) || ((shour > ehour) && (metroComboBox7.Text == "AM" && metroComboBox8.Text == "AM")) || ((shour > ehour) && (metroComboBox7.Text == "PM" && metroComboBox8.Text == "PM")))
                    {
                        MessageBox.Show("Invalid End Time!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (metroDateTime1.Value.DayOfWeek == DayOfWeek.Sunday)
                    {
                        MessageBox.Show("Clinic is closed every Sunday.", "Closed on Sundays", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string stquery = "SELECT * FROM schedule WHERE ('" + start + "' BETWEEN sched_stime AND sched_etime AND sched_status = 'Scheduled') OR ('" + end + "' BETWEEN sched_stime AND sched_etime AND sched_status = 'Scheduled')";
                        string etquery = "SELECT * FROM schedule WHERE (sched_stime BETWEEN '" + start + "' AND '" + end + "' AND sched_status = 'Scheduled') OR  (sched_etime BETWEEN '" + start + "' AND '" + end + "' AND sched_status = 'Scheduled')";

                        conn.Open();
                        MySqlCommand commStartSelect = new MySqlCommand(stquery, conn);
                        MySqlDataAdapter adps = new MySqlDataAdapter(commStartSelect);
                        MySqlCommand commEndSelect = new MySqlCommand(etquery, conn);
                        MySqlDataAdapter adpe = new MySqlDataAdapter(commEndSelect);

                        conn.Close();

                        DataTable dtst = new DataTable();
                        adps.Fill(dtst);
                        DataTable dtet = new DataTable();
                        adpe.Fill(dtet);

                        if (dtst.Rows.Count > 0 || dtet.Rows.Count > 0)
                        {
                            MessageBox.Show("Time in Conflict with another schedule!", "Conflict Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string iquery = "INSERT INTO schedule(schedule_id, patient_fname, patient_lname, patient_address, patient_bdate, patient_email, patient_num, patient_year, sched_stime, sched_etime, sched_status, sched_doctor, sched_encoder, sched_date, starthour, startmin, startapm, endhour, endmin, endapm, start_time, end_time) VALUES(schedule_id, '" + metroTextBox3.Text + "', '" + metroTextBox4.Text + "', '" + metroTextBox5.Text + "', '" + metroDateTime2.Text + "', '" + metroTextBox7.Text + "' ,'" + metroTextBox8.Text + "', '" + textBox1.Text + "', '" + start + "', '" + end + "', 'Scheduled', '" + metroTextBox2.Text + "', + '" + label4.Text + "' , + '" + metroDateTime1.Text + "' , + '" + metroComboBox1.Text + "' , + '" + metroComboBox2.Text + "', + '" + metroComboBox7.Text + "', + '" + metroComboBox3.Text + "', + '" + metroComboBox4.Text + "', + '" + metroComboBox8.Text + "', '" + start_time + "', '" + end_time + "')";
                            conn.Open();
                            MySqlCommand commi = new MySqlCommand(iquery, conn);
                            MySqlDataAdapter adp2 = new MySqlDataAdapter(commi);
                            commi.ExecuteNonQuery();
                            conn.Close();

                            string qquery = "UPDATE treatment_line SET sched_id = LAST_INSERT_ID() where treatment_id=" + id;
                     
                            conn.Open();
                            MySqlCommand commqq = new MySqlCommand(qquery, conn);
                            MySqlDataAdapter adp = new MySqlDataAdapter(commqq);
                            commqq.ExecuteNonQuery();
                            conn.Close();


                            MessageBox.Show("Appointment Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadAll();

                        }
                    }
                }
                else
                {
                    MessageBox.Show("The clinic is only open from 8 AM to 6 PM", "TIME!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                
            }
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                string qquery = "Insert into treatment_line VALUES (NULL, '" + id + "')";
                conn.Open();
                MySqlCommand commqq = new MySqlCommand(qquery, conn);
                commqq.ExecuteNonQuery();
                conn.Close();
            }
        }


        private void metroButton3_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        public void loadAll()
        {
            string squery = "SELECT * FROM schedule where sched_status = 'Scheduled'";

            conn.Open();
            MySqlCommand comm3 = new MySqlCommand(squery, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm3);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView1.DataSource = dt;

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns["schedule_id"].Visible = false;
            dataGridView1.Columns["patient_fname"].HeaderText = "First Name";
            dataGridView1.Columns["patient_lname"].HeaderText = "Last Name";
            dataGridView1.Columns["patient_address"].Visible = false;
            dataGridView1.Columns["patient_email"].Visible = false;
            dataGridView1.Columns["patient_bdate"].Visible = false;
            dataGridView1.Columns["patient_num"].Visible = false;
            dataGridView1.Columns["patient_year"].Visible = false;
            dataGridView1.Columns["sched_stime"].Visible = false;
            dataGridView1.Columns["sched_etime"].Visible = false;
            dataGridView1.Columns["sched_date"].HeaderText = "Date";
            dataGridView1.Columns["start_time"].HeaderText = "Time Start";
            dataGridView1.Columns["end_time"].HeaderText = "Time End";
            dataGridView1.Columns["sched_status"].HeaderText = "Status";
            dataGridView1.Columns["sched_doctor"].HeaderText = "Doctor";
            dataGridView1.Columns["sched_encoder"].HeaderText = "Reserved By";
            dataGridView1.Columns["starthour"].Visible = false;
            dataGridView1.Columns["startmin"].Visible = false;
            dataGridView1.Columns["startapm"].Visible = false;
            dataGridView1.Columns["endhour"].Visible = false;
            dataGridView1.Columns["endapm"].Visible = false;
            dataGridView1.Columns["endmin"].Visible = false;


            dataGridView1.Sort(dataGridView1.Columns[2], ListSortDirection.Ascending);

        }

        public void loadPatients()
        {

            string select = "SELECT * FROM patient";

            conn.Open();
            MySqlCommand comm = new MySqlCommand(select, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            dataGridView4.DataSource = dt;



            dataGridView4.Columns["patient_id"].Visible = false;
            dataGridView4.Columns["patient_address"].Visible = false;
            dataGridView4.Columns["patient_bdate"].Visible = false;
            dataGridView4.Columns["patient_email"].Visible = false;
            dataGridView4.Columns["patient_num"].Visible = false;
            dataGridView4.Columns["patient_year"].Visible = false;
            dataGridView4.Columns["patient_fname"].HeaderText = "First Name";
            dataGridView4.Columns["patient_lname"].HeaderText = "Last Name";



        }

        public void loadTreatment()
        {
            string trquery = "SELECT * FROM treatment_line";

            conn.Open();
            MySqlCommand comm9 = new MySqlCommand(trquery, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm9);
            conn.Close();
            DataTable data = new DataTable();
            adp.Fill(data);

            dataGridView3.DataSource = data;

            dataGridView3.RowHeadersVisible = false;
            dataGridView3.Columns["treatment_id"].Visible = false;
            dataGridView3.Columns["sched_id"].Visible = false;
            dataGridView3.Columns["treatment"].HeaderText = "Treatment/s";
            dataGridView3.Columns["treat_stat"].Visible = false;

            dataGridView3.Sort(dataGridView3.Columns[0], ListSortDirection.Ascending);
        }



        public void clearAll()
        {
            metroTextBox3.Text = "";
            metroTextBox4.Text = "";
            metroTextBox5.Text = "";
            metroDateTime2.Text = "";
            metroTextBox7.Text = "";
            metroTextBox8.Text = "";
            textBox1.Text = "";
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (metroTextBox3.Text == "" || metroTextBox4.Text == "" || metroTextBox5.Text == "" || metroDateTime2.Text == "" || metroTextBox7.Text == "" || metroTextBox8.Text == "")
            {
                MessageBox.Show("Please fill up all data.", "Patient Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string fname = metroTextBox3.Text;
                string lname = metroTextBox4.Text;
                string address = metroTextBox5.Text;
                string bdate = metroDateTime2.Text;
                string email = metroTextBox7.Text;
                string num = metroTextBox8.Text;
                string year = textBox1.Text;

                panel2.Hide();
                button11.Enabled = true;

                string fullname = fname + " " + lname;

                metroTextBox1.Text = fullname;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.Year.ToString();

        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            if (metroTextBox12.Text == "" || metroTextBox11.Text == "" || metroTextBox10.Text == "" || metroTextBox9.Text == "" || metroTextBox6.Text == "" || metroTextBox8.Text == "")
            {
                MessageBox.Show("Please fill up all data.", "Doctor Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string fname = metroTextBox12.Text;
                string lname = metroTextBox11.Text;

                string fullname = fname + " " + lname;
                metroTextBox2.Text = fullname;

                panel3.Hide();
                button1.Enabled = true;

                string dquery = "INSERT INTO doctor(doctor_id, doctor_fname, doctor_lname, doctor_specialty, doctor_email, doctor_num) VALUES(doctor_id, '" + metroTextBox12.Text + "', '" + metroTextBox11.Text + "', '" + metroTextBox10.Text + "', '" + metroTextBox9.Text + "', '" + metroTextBox6.Text + "')";
                conn.Open();
                MySqlCommand commd = new MySqlCommand(dquery, conn);
                MySqlDataAdapter adp2 = new MySqlDataAdapter(commd);
                commd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Doctor Successfully Added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void clear2()
        {
            metroTextBox1.Text = "";
            metroDateTime1.Text = "";
            metroComboBox1.Text = "";
            metroComboBox2.Text = "";
            metroComboBox7.Text = "";
            metroComboBox3.Text = "";
            metroComboBox4.Text = "";
            metroComboBox8.Text = "";
            metroTextBox2.Text = "";

        }

        private void button9_Click(object sender, EventArgs e)
        {
            clear2();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            panel4.Show();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void metroButton11_Click(object sender, EventArgs e)
        {
            panel4.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            panel5.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "Others")
            {
                panel6.Show();
            }
            else
            {
                panel6.Hide();
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }



        private void pictureBox4_Click(object sender, EventArgs e)
        {
            panel5.Hide();
        }

        private string selected_schedule_status;

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string firstname = dataGridView1.Rows[e.RowIndex].Cells["patient_fname"].Value.ToString();
            string lastname = dataGridView1.Rows[e.RowIndex].Cells["patient_lname"].Value.ToString();
            string fullname = firstname + " " + lastname;

            textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["schedule_id"].Value.ToString();
            metroTextBox1.Text = fullname;
            metroDateTime1.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells["sched_date"].Value.ToString());
            metroComboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["starthour"].Value.ToString();
            metroComboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["startmin"].Value.ToString();
            metroComboBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["startapm"].Value.ToString();
            metroComboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["endhour"].Value.ToString();
            metroComboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["endmin"].Value.ToString();
            metroComboBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["endapm"].Value.ToString();
            metroTextBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["sched_doctor"].Value.ToString();

            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                textBox6.Text = textBox5.Text;

            }

            selected_schedule_status = dataGridView1.Rows[e.RowIndex].Cells["sched_status"].Value.ToString();

            if (selected_schedule_status == "Scheduled")
            {
                panel1.Hide();
                panel8.Show();
            }

            string tquery = "SELECT * FROM treatment_line where sched_id = '" + textBox5.Text + "'";

            conn.Open();
            MySqlCommand comm4 = new MySqlCommand(tquery, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm4);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            dataGridView3.DataSource = dt;

            dataGridView3.RowHeadersVisible = false;
            dataGridView3.Columns["treatment_id"].Visible = false;
            dataGridView3.Columns["sched_id"].Visible = false;
            dataGridView3.Columns["treatment"].HeaderText = "Treatment/s";
            dataGridView3.Columns["treat_stat"].Visible = false;

            dataGridView3.Sort(dataGridView3.Columns[0], ListSortDirection.Ascending);

        }



        private void button7_Click(object sender, EventArgs e)
        {
            string sel = "SELECT treat_id FROM treat WHERE description = '"+cmbTreat.Text+"'";
            conn.Open();
            MySqlCommand comm = new MySqlCommand(sel, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(comm);
            comm.ExecuteNonQuery();
            DataTable dt = new DataTable();
            adp.Fill(dt);
            conn.Close();
            string id = dt.Rows[0][0].ToString();
            dataGridView3.Rows.Add(id, cmbTreat.Text);
            /*
            if (comboBox1.Text == "Others" && textBox4.Text == "")
            {
                MessageBox.Show("Please specify treatment to be done.", "Treatment Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Please select treatment to be done.", "Treatment Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (comboBox1.Text == "Others")
                {
                    string dquery = "INSERT INTO treatment_line(treatment_id, treatment, treat_stat) VALUES(treatment_id, '" + textBox4.Text + "', 'Booked')";
                    conn.Open();
                    MySqlCommand commd = new MySqlCommand(dquery, conn);
                    MySqlDataAdapter adp2 = new MySqlDataAdapter(commd);
                    commd.ExecuteNonQuery();
                    conn.Close();

                    loadTreatment();

                }
                else
                {
                    string dquery = "INSERT INTO treatment_line(treatment_id, treatment, treat_stat) VALUES(treatment_id, '" + comboBox1.Text + "', 'Booked')";
                    conn.Open();
                    MySqlCommand commd = new MySqlCommand(dquery, conn);
                    MySqlDataAdapter adp2 = new MySqlDataAdapter(commd);
                    commd.ExecuteNonQuery();
                    conn.Close();

                    loadTreatment();
                }

            }
            */
        }

        private void button8_Click(object sender, EventArgs e)
        {

            if (dataGridView3.Rows.Count == 0 || dataGridView3.Rows == null)
            {
                MessageBox.Show("You did not select any treatment.", "Treatment Adding", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Treatment/s Added to Schedule", "Treatment Adding", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panel5.Hide();
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string selected_fn;
            string selected_ln;

            selected_fn = dataGridView4.Rows[e.RowIndex].Cells["patient_fname"].Value.ToString();
            selected_ln = dataGridView4.Rows[e.RowIndex].Cells["patient_lname"].Value.ToString();

            metroTextBox1.Text = selected_fn + " " + selected_ln;
            panel7.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //panel8.Hide();
            panel8.BringToFront();
            clear2();



        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            //panel8.Hide();
            panel8.BringToFront();
            clear2();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            panel7.Show();

            loadPatients();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you wish to proceed to treatment?", "Appointment Confirmation", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = "SELECT * FROM schedule WHERE schedule_id = '" + textBox5.Text + "'";

                conn.Open(); //open MySql connection
                MySqlCommand comm = new MySqlCommand(query, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);
                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    string firstname = dt.Rows[0]["patient_fname"].ToString();
                    string lastname = dt.Rows[0][2].ToString();
                    string address = dt.Rows[0][3].ToString();
                    string bdate = dt.Rows[0][4].ToString();
                    string email = dt.Rows[0][5].ToString();
                    string num = dt.Rows[0][6].ToString();
                    string year = dt.Rows[0][7].ToString();

                    string squery = "SELECT * from PATIENT WHERE patient_fname = '" + firstname + "' AND patient_lname = '" + lastname + "'";

                    conn.Open();
                    MySqlCommand commse = new MySqlCommand(squery, conn);
                    MySqlDataAdapter adp6 = new MySqlDataAdapter(commse);
                    conn.Close();
                    DataTable dat = new DataTable();
                    adp6.Fill(dat);

                    if (dat.Rows.Count == 1)
                    {
                        string uquery = "UPDATE schedule SET sched_status = 'Ongoing' WHERE schedule_id = '" + textBox5.Text + "'";

                        conn.Open();
                        MySqlCommand commu = new MySqlCommand(uquery, conn);
                        MySqlDataAdapter adp3 = new MySqlDataAdapter(commu);
                        commu.ExecuteNonQuery();
                        conn.Close();

                        loadAll();
                    }
                    else
                    {
                        string uquery = "UPDATE schedule SET sched_status = 'Ongoing' WHERE schedule_id = '" + textBox5.Text + "'";
                        string iquery = "INSERT INTO patient(patient_id, patient_fname, patient_lname, patient_address, patient_bdate, patient_email, patient_num, patient_year) VALUES(patient_id, '" + firstname + "', '" + lastname + "', '" + address + "', '" + bdate + "', '" + email + "', '" + num + "', '" + year + "')";

                        conn.Open();
                        MySqlCommand commu = new MySqlCommand(uquery, conn);
                        MySqlCommand commi = new MySqlCommand(iquery, conn);
                        MySqlDataAdapter adp3 = new MySqlDataAdapter(commu);
                        MySqlDataAdapter adp7 = new MySqlDataAdapter(commi);
                        commu.ExecuteNonQuery();
                        commi.ExecuteNonQuery();
                        conn.Close();

                        loadAll();

                    }


                }
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel7.Hide();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            if (metroTextBox1.Text == " ")
            {
                string select = "SELECT * FROM patient";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(select, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView4.DataSource = dt;



                dataGridView4.Columns["patient_id"].Visible = false;
                dataGridView4.Columns["patient_address"].Visible = false;
                dataGridView4.Columns["patient_bdate"].Visible = false;
                dataGridView4.Columns["patient_email"].Visible = false;
                dataGridView4.Columns["patient_num"].Visible = false;
                dataGridView4.Columns["patient_year"].Visible = false;
                dataGridView4.Columns["patient_fname"].HeaderText = "First Name";
                dataGridView4.Columns["patient_lname"].HeaderText = "Last Name";

            }
            else
            {
                string select = "SELECT * FROM patient WHERE patient_fname LIKE " + "'%" + metroTextBox1.Text + "%' || patient_lname LIKE " + "'%" + metroTextBox1.Text + "%'";

                conn.Open();
                MySqlCommand comm = new MySqlCommand(select, conn);
                MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                conn.Close();
                DataTable dt = new DataTable();
                adp.Fill(dt);
                dataGridView4.DataSource = dt;

                if (dt.Rows.Count != 0)
                {


                    dataGridView4.Columns["patient_id"].Visible = false;
                    dataGridView4.Columns["patient_address"].Visible = false;
                    dataGridView4.Columns["patient_bdate"].Visible = false;
                    dataGridView4.Columns["patient_email"].Visible = false;
                    dataGridView4.Columns["patient_num"].Visible = false;
                    dataGridView4.Columns["patient_year"].Visible = false;
                    dataGridView4.Columns["patient_fname"].HeaderText = "First Name";
                    dataGridView4.Columns["patient_lname"].HeaderText = "Last Name";

                }
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            string uiquery = "UPDATE schedule SET sched_status = 'Cancelled' WHERE schedule_id = '" + textBox5.Text + "'";


            conn.Open();
            MySqlCommand commui = new MySqlCommand(uiquery, conn);
            MySqlDataAdapter adp7 = new MySqlDataAdapter(commui);
            commui.ExecuteNonQuery();
            conn.Close();

            loadAll();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "" || metroDateTime1.Text == "" || metroComboBox1.Text == "" || metroComboBox2.Text == "" || metroComboBox7.Text == "" || metroComboBox3.Text == "" || metroComboBox4.Text == "" || metroComboBox8.Text == "" || metroTextBox2.Text == "")
            {
                MessageBox.Show("Please fill up all data.", "Appointment Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string start;
                string end;
                string date = metroDateTime1.Text;

                int shour = int.Parse(metroComboBox1.Text);
                int ehour = int.Parse(metroComboBox3.Text);

                metroDateTime1.MinDate = DateTime.Today;

                if (metroComboBox7.Text == "AM")
                {
                    shour = shour + 0;
                }
                else if (metroComboBox7.Text == "PM")
                {
                    if (shour == 12)
                    {
                        shour = shour + 0;
                    }
                    else
                    {
                        shour = shour + 12;
                    }
                }
                else
                {
                    MessageBox.Show("Please select if it's in AM or PM", "Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (metroComboBox8.Text == "AM")
                {
                    ehour = ehour + 0;
                }
                else if (metroComboBox8.Text == "PM")
                {
                    if (ehour == 12)
                    {
                        ehour = ehour + 0;
                    }
                    else
                    {
                        ehour = ehour + 12;
                    }
                }
                else
                {
                    MessageBox.Show("Please select if it's in AM or PM", "Time", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                int sminute = int.Parse(metroComboBox2.Text);
                int eminute = int.Parse(metroComboBox4.Text);

                start = date + " " + shour + ":" + metroComboBox2.Text + ":00";
                end = date + " " + ehour + ":" + metroComboBox4.Text + ":00";

                string start_time = shour + ":" + metroComboBox2.Text + " " + metroComboBox7.Text;
                string end_time = ehour + ":" + metroComboBox4.Text + " " + metroComboBox8.Text;


                if ((shour >= 8 && ehour < 18))
                {
                    if ((shour == ehour && sminute > eminute) || ((shour > ehour) && (metroComboBox7.Text == "AM" && metroComboBox8.Text == "AM")) || ((shour > ehour) && (metroComboBox7.Text == "PM" && metroComboBox8.Text == "PM")))
                    {
                        MessageBox.Show("Invalid End Time!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (metroDateTime1.Value.DayOfWeek == DayOfWeek.Sunday)
                    {
                        MessageBox.Show("Clinic is closed every Sunday.", "Closed on Sundays", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        string stquery = "SELECT * FROM schedule WHERE ('" + start + "' BETWEEN sched_stime AND sched_etime AND sched_status = 'Scheduled') OR ('" + end + "' BETWEEN sched_stime AND sched_etime AND sched_status = 'Scheduled')";
                        string etquery = "SELECT * FROM schedule WHERE (sched_stime BETWEEN '" + start + "' AND '" + end + "' AND sched_status = 'Scheduled') OR  (sched_etime BETWEEN '" + start + "' AND '" + end + "' AND sched_status = 'Scheduled')";

                        conn.Open();
                        MySqlCommand commStartSelect = new MySqlCommand(stquery, conn);
                        MySqlDataAdapter adps = new MySqlDataAdapter(commStartSelect);
                        MySqlCommand commEndSelect = new MySqlCommand(etquery, conn);
                        MySqlDataAdapter adpe = new MySqlDataAdapter(commEndSelect);

                        conn.Close();

                        DataTable dtst = new DataTable();
                        adps.Fill(dtst);
                        DataTable dtet = new DataTable();
                        adpe.Fill(dtet);

                        if (dtst.Rows.Count > 0 || dtet.Rows.Count > 0)
                        {
                            MessageBox.Show("Time in Conflict with another schedule!", "Conflict Schedule", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            string select = "SELECT * FROM patient";

                            conn.Open();
                            MySqlCommand comm = new MySqlCommand(select, conn);
                            MySqlDataAdapter adp = new MySqlDataAdapter(comm);

                            conn.Close();
                            DataTable dt = new DataTable();
                            adp.Fill(dt);
                            dataGridView4.DataSource = dt;

                            if (dt.Rows.Count == 1)
                            {

                                string firstname1 = dt.Rows[0]["patient_fname"].ToString();
                                string lastname1 = dt.Rows[0]["patient_lname"].ToString();





                                string upquery = "UPDATE schedule set patient_fname = '" + firstname1 + "', patient_lname = '" + lastname1 + "' WHERE schedule_id = '" + textBox5.Text + "'";
                                MySqlCommand commup = new MySqlCommand(upquery, conn);
                                MySqlDataAdapter adp8 = new MySqlDataAdapter(commup);
                                commup.ExecuteNonQuery();
                                conn.Close();

                                MessageBox.Show("Appointment Added", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                loadAll();
                            }



                        }
                    }
                }
                else
                {
                    MessageBox.Show("The clinic is only open from 8 AM to 6 PM", "TIME!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
