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
    public partial class Form2 : MetroFramework.Forms.MetroForm
    {

        public Form1 previousform;
        public Form2 secondform;
        public ServiceForm serviceform;
        public AppointmentForm appointmentform;
        public StockForm stockform;
        public ItemForm itemform;
        public PurchaseOrderForm purchaseorderform;
        public DeliveryForm deliveryform;




        MySqlConnection conn;
        public Form2()
        {
            InitializeComponent();
            conn = new MySqlConnection("Server=localhost;Database=system;Uid=root; Pwd=root;");
        }

        public int id { get; set; }


        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    
        private void Form2_Load(object sender, EventArgs e)
        {
            label6.Text = this.getusertype;
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            previousform.Show();
            this.Close();
        }

       

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
           
               
                Form4 fourthform = new Form4();
                fourthform.id = id;
                fourthform.secondform = this;
                fourthform.Show();
                this.Hide();
            
        }

        public string getusertype { get; set; }
        private void label6_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            Form5 fifthform = new Form5();
            fifthform.secondform = this;
            fifthform.Show();
            this.Hide();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {



        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            previousform.Show();
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form6 sixthform = new Form6();
            sixthform.secondform = this;
            sixthform.Show();

            string app = "SELECT * from appointment_line WHERE appline_status = 'Ongoing'";


            conn.Open();
            MySqlCommand com = new MySqlCommand(app, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            sixthform.dataGridView1.DataSource = dt;
            sixthform.dataGridView1.Columns["appline_id"].Visible = false;
            sixthform.dataGridView1.Columns["appline_name"].Visible = false;
            sixthform.dataGridView1.Columns["appline_date"].HeaderText = "Appointment Date";
            sixthform.dataGridView1.Columns["appline_starttime"].HeaderText = "Start Time";
            sixthform.dataGridView1.Columns["appline_endtime"].HeaderText = "End Time";
            sixthform.dataGridView1.Columns["appline_status"].Visible = false;
            sixthform.dataGridView1.Columns["treatment"].Visible = false;
            
            sixthform.dataGridView1.Sort(sixthform.dataGridView1.Columns[2], ListSortDirection.Ascending);




            sixthform.panel1.Hide();
            sixthform.panel2.Hide();
            sixthform.panel3.Hide();
            
            this.Hide();
            
        }

        private void metroContextMenu1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void metroPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void metroTile1_Click(object sender, EventArgs e)
        {

        }

        

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            Form4 fourthform = new Form4();
            fourthform.id = id;
            fourthform.secondform = this;
            fourthform.Show();
            this.Hide();
        }

        private void metroUserControl1_Load(object sender, EventArgs e)
        {

        }

        private void todaysAppointmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 sixthform = new Form6();
            sixthform.secondform = this;
            sixthform.Show();

            string app = "SELECT * from appointment_line WHERE appline_status = 'Ongoing'";


            conn.Open();
            MySqlCommand com = new MySqlCommand(app, conn);
            MySqlDataAdapter adp = new MySqlDataAdapter(com);
            conn.Close();
            DataTable dt = new DataTable();
            adp.Fill(dt);

            sixthform.dataGridView1.DataSource = dt;
            sixthform.dataGridView1.Columns["appline_id"].Visible = false;
            sixthform.dataGridView1.Columns["appline_name"].Visible = false;
            sixthform.dataGridView1.Columns["appline_date"].HeaderText = "Appointment Date";
            sixthform.dataGridView1.Columns["appline_starttime"].HeaderText = "Start Time";
            sixthform.dataGridView1.Columns["appline_endtime"].HeaderText = "End Time";
            sixthform.dataGridView1.Columns["appline_status"].Visible = false;
            sixthform.dataGridView1.Columns["treatment"].Visible = false;

            sixthform.dataGridView1.Sort(sixthform.dataGridView1.Columns[2], ListSortDirection.Ascending);




            sixthform.panel1.Hide();
            sixthform.panel2.Hide();
            sixthform.panel3.Hide();

            this.Hide();
        }

        private void htmlToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void metroToolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void metroLabel1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click_2(object sender, EventArgs e)
        {
            previousform.Show();
            this.Close();
        }

        private void metroUserControl1_Load_1(object sender, EventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        public string getfirstname { get; set; }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
                metroPanel2.Controls.Clear();

                AppointmentForm appointmentform = new AppointmentForm();
                appointmentform.FormBorderStyle = FormBorderStyle.None;
                appointmentform.Dock = DockStyle.Fill;
                appointmentform.BringToFront();
                appointmentform.TopLevel = false;
                appointmentform.AutoScroll = true;
                metroPanel2.Controls.Add(appointmentform);
                appointmentform.label4.Text = this.getfirstname + ",  " + this.getusertype;
                
                appointmentform.Show();
                
            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
            
        }

        private void toolStripSplitButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }

        private void metroPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void newItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
           metroPanel2.Controls.Clear();


            ItemForm itemform = new ItemForm();
            itemform.FormBorderStyle = FormBorderStyle.None;
            itemform.Dock = DockStyle.Fill;
            itemform.BringToFront();
            itemform.TopLevel = false;
            itemform.AutoScroll = true;
            metroPanel2.Controls.Add(itemform);
            //stockform.label4.Text = this.getfirstname + ",  " + this.getusertype;
            itemform.Show();
        }

        private void purchaseOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void toolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            metroPanel2.Controls.Clear();

            StockForm stockform = new StockForm();
            stockform.FormBorderStyle = FormBorderStyle.None;
            stockform.Dock = DockStyle.Fill;
            stockform.BringToFront();
            stockform.TopLevel = false;
            stockform.AutoScroll = true;
            metroPanel2.Controls.Add(stockform);
            //stockform.label4.Text = this.getfirstname + ",  " + this.getusertype;
            stockform.Show();
        }

        private void purchaseOrderToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            metroPanel2.Controls.Clear();

            PurchaseOrderForm purchaseorderform = new PurchaseOrderForm();
            purchaseorderform.FormBorderStyle = FormBorderStyle.None;
            purchaseorderform.Dock = DockStyle.Fill;
            purchaseorderform.BringToFront();
            purchaseorderform.TopLevel = false;
            purchaseorderform.AutoScroll = true;
            metroPanel2.Controls.Add(purchaseorderform);
            //purchaseorderform.label4.Text = this.getfirstname + ",  " + this.getusertype;

            purchaseorderform.Show();
        }

        private void deliveriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroPanel2.Controls.Clear();

            DeliveryForm deliveryform = new DeliveryForm();
            deliveryform.FormBorderStyle = FormBorderStyle.None;
            deliveryform.Dock = DockStyle.Fill;
            deliveryform.BringToFront();
            deliveryform.TopLevel = false;
            deliveryform.AutoScroll = true;
            metroPanel2.Controls.Add(deliveryform);
            //purchaseorderform.label4.Text = this.getfirstname + ",  " + this.getusertype;

            deliveryform.Show();
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroPanel2.Controls.Clear();

            SupplierForm supplierform = new SupplierForm();
            supplierform.FormBorderStyle = FormBorderStyle.None;
            supplierform.Dock = DockStyle.Fill;
            supplierform.BringToFront();
            supplierform.TopLevel = false;
            supplierform.AutoScroll = true;
            metroPanel2.Controls.Add(supplierform);
            //purchaseorderform.label4.Text = this.getfirstname + ",  " + this.getusertype;

            supplierform.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            metroPanel2.Controls.Clear();

            PatientsRecordForm patientsrecordform = new PatientsRecordForm();
            patientsrecordform.FormBorderStyle = FormBorderStyle.None;
            patientsrecordform.Dock = DockStyle.Fill;
            patientsrecordform.BringToFront();
            patientsrecordform.TopLevel = false;
            patientsrecordform.AutoScroll = true;
            metroPanel2.Controls.Add(patientsrecordform);
            //purchaseorderform.label4.Text = this.getfirstname + ",  " + this.getusertype;

            patientsrecordform.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {

        }

        private void createProductSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroPanel2.Controls.Clear();

            SalesProductForm salesproductform = new SalesProductForm();
            salesproductform.FormBorderStyle = FormBorderStyle.None;
            salesproductform.Dock = DockStyle.Fill;
            salesproductform.BringToFront();
            salesproductform.TopLevel = false;
            salesproductform.AutoScroll = true;
            metroPanel2.Controls.Add(salesproductform);

            //serviceform.label4.Text = this.getfirstname + ",  " + this.getusertype;
            salesproductform.Show();
        }

        private void createProcedureSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            metroPanel2.Controls.Clear();

            SalesProceduresForm salesproceduresform = new SalesProceduresForm();
            salesproceduresform.FormBorderStyle = FormBorderStyle.None;
            salesproceduresform.Dock = DockStyle.Fill;
            salesproceduresform.BringToFront();
            salesproceduresform.TopLevel = false;
            salesproceduresform.AutoScroll = true;
            metroPanel2.Controls.Add(salesproceduresform);

            //serviceform.label4.Text = this.getfirstname + ",  " + this.getusertype;
            salesproceduresform.Show();
        }

        private void toolStripSplitButton2_Click(object sender, EventArgs e)
        {
            metroPanel2.Controls.Clear();

            ServiceForm serviceform = new ServiceForm();
            serviceform.FormBorderStyle = FormBorderStyle.None;
            serviceform.Dock = DockStyle.Fill;
            serviceform.BringToFront();
            serviceform.TopLevel = false;
            serviceform.AutoScroll = true;
            metroPanel2.Controls.Add(serviceform);
            
            //serviceform.label4.Text = this.getfirstname + ",  " + this.getusertype;
            serviceform.Show();
        }
    }
    }
   
    

