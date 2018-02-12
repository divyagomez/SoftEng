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
    public partial class UserControl1 : UserControl
    {
        MySqlConnection conn;

        public Form1 previousform; 

        public static UserControl1 _instance;

        public static UserControl1 Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserControl1();
                return _instance;
            }
        }


        public UserControl1()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=system;Uid=root; Pwd=root;");
        }

        public string firstname { get; set; }
        private void UserControl1_Load(object sender, EventArgs e)
        {
            label3.Text = "Today: " + DateTime.Now.ToString();
            textBox1.Text = DateTime.Now.Year.ToString();
            panel2.Hide();
            metroGrid2.Hide();
            metroLabel18.Hide();
            metroLabel19.Show();
            button13.Hide();
            panel3.Hide();
            panel4.Hide();


        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            panel2.Show(); 
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (metroTextBox1.Text == "" || metroDateTime1.Text == "" || metroComboBox1.Text == "" || metroComboBox2.Text == "" || metroComboBox7.Text == "" || metroComboBox3.Text == "" || metroComboBox4.Text == "" || metroComboBox8.Text == "" || metroComboBox5.Text == "" || metroTextBox2.Text == "")
            {
                MessageBox.Show("Please fill up all data.", "Appointment Details", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string start;
                string end;
                string date = metroDateTime1.Text.ToString();

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

                start = metroDateTime1 + " " + shour + ":" + metroComboBox2.Text + ":00";
                end = metroDateTime1 + " " + ehour + ":" + metroComboBox2.Text + ":00";


                if ((shour >= 7 && ehour < 17))
                {
                    if ((shour == ehour && sminute > eminute) || ((shour > ehour) && (metroComboBox7.Text == "AM" && metroComboBox8.Text == "AM")) || ((shour > ehour) && (metroComboBox7.Text == "PM" && metroComboBox8.Text == "PM")))
                    {
                        MessageBox.Show("Invalid End Time!", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string stquery = "SELECT * FROM schedule WHERE ('" + date + "' LIKE sched_date AND '" + start + "' BETWEEN sched_stime AND sched_etime AND sched_status = 'Scheduled') OR ('" + date + "' LIKE sched_date AND '" + end + "' BETWEEN sched_stime AND sched_etime AND sched_status = 'Scheduled')";
                        string etquery = "SELECT * FROM schedule WHERE ('" + date + "' LIKE sched_date AND sched_stime BETWEEN '" + start + "' AND '" + end + "' AND sched_status = 'Scheduled') OR  ('" + date + "' LIKE sched_date AND sched_etime BETWEEN '" + start + "' AND '" + end + "' AND sched_status = 'Scheduled')";

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
                            
                        }
                    }
                }

               
            }
        }
        private void metroTextBox1_Click(object sender, EventArgs e)
        {
        }

        private void metroLabel13_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            if (metroTextBox3.Text == "" || metroTextBox4.Text == "" || metroTextBox5.Text == "" || dateTimePicker1.Text == "" || metroTextBox7.Text == "" || metroTextBox8.Text == "")
            {
                MessageBox.Show("Please fill up all data.", "Patient Registration", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string fname = metroTextBox3.Text;
                string lname = metroTextBox4.Text;
                string address = metroTextBox5.Text;
                string bdate = dateTimePicker1.Text.ToString();
                string email = metroTextBox7.Text;
                string num = metroTextBox8.Text;
                string year = textBox1.Text;

                panel2.Hide();

                string fullname = fname + " " + lname;

                metroTextBox1.Text = fullname; 

            }
        }
  
   

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void metroGrid1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void metroTextBox9_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            textBox1.Text = DateTime.Now.Year.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = DateTime.Now.Year.ToString();
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            panel2.Hide();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            metroGrid2.Show();
            metroLabel19.Hide();
            metroLabel18.Show();
            button13.Show();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            metroGrid2.Hide();
            metroLabel18.Hide();
            metroLabel19.Show();
            button13.Hide();
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        void clearAll()
        {
            metroTextBox3.Text = "";
            metroTextBox4.Text = "";
            metroTextBox5.Text = "";
            dateTimePicker1.Text = "";
            metroTextBox7.Text = "";
            metroTextBox8.Text = "";
            textBox1.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            panel3.Show();
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            panel3.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            panel4.Hide();
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void encoder_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
