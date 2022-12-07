using BallParkApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallParkApplication
{
    public partial class BookingPage : Form
    {
        OleDbConnection oleDbConnection;
        OleDbCommand command2;
        public BookingPage()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["BallPark"];
            oleDbConnection.Open();
            int seatId = 0;
            int price = 0;
            if (this.comboBox1.Text == "Bronze")
            {
                seatId = 1;
                price = 500;
            }
            else if (this.comboBox1.Text == "Silver")
            {
                seatId = 2;
                price = 750;
            }
            else
            {
                seatId = 3;
                price = 1000;
            }
            var dateTime = DateTime.Now.ToString("MM/dd/yyyy");
            var command = String.Format("Insert INTO [Ticket] ([Ticket_No], [Price], [SeatId], [Ticket_Date]) VALUES ({0}, {1}, {2}, '{3}')", textBox1.Text, price * Convert.ToInt32(this.textBox1.Text), seatId, dateTime);
            OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            command2.ExecuteNonQuery();
            Utility.Utility.Section = this.comboBox1.Text;
            Utility.Utility.No_of_Seats = Convert.ToInt32(this.textBox1.Text);
            Utility.Utility.Amount = price;
            command = String.Format("Insert INTO [Payment] ([Amount], [Payment_Type], [Customer_Id], [Payment_Date]) VALUES ({0}, '{1}', {2}, '{3}')", price * Convert.ToInt32(this.textBox1.Text), "Card", Utility.Utility.Customer.Id, DateTime.Now.ToString("MM/dd/yyyy"));
            command2 = new OleDbCommand(command, oleDbConnection);
            command2.ExecuteNonQuery();
            PaymentPage page = new PaymentPage();
            page.Show();
            oleDbConnection.Close();
            this.Close();
        }

        private void BookingPage_Load(object sender, EventArgs e)
        {
            List<string> Row = new List<string>();
            Row.Add("Bronze");
            Row.Add("Silver");
            Row.Add("Gold");
            this.comboBox1.DataSource = Row;
            //oleDbConnection = new OleDbConnection();
            //oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["BallPark"];
            //oleDbConnection.Open();
            //var command = String.Format("Select * from Ticket");
            //OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            //OleDbDataAdapter adapter = new OleDbDataAdapter();
            //adapter.SelectCommand = command2;
            //var ds = new DataSet();
            //adapter.Fill(ds);
            //var dt = ds.Tables[0];
            //List<Ticket> tickets = new List<Ticket>();
            //foreach(DataRow dr in dt.Rows)
            //{
            //    var ticket = new Ticket
            //    {
            //        TicketId = Convert.ToInt32(dr["Ticket_Id"]),
            //        TicketNo = Convert.ToInt32(dr["Ticket_No"]),
            //        Price = Convert.ToInt32(dr["Price"]),
            //        SeatId = Convert.ToInt32(dr["SeatId"]),
            //        Date = dr["Ticket_Date"].ToString(),
            //        CustomerId = Convert.ToInt32(dr["Cid"])
            //    };

            //    if(ticket.CustomerId == Utility.Utility.Customer.Cid)
            //    {
            //        tickets.Add(ticket);
            //    }
            //}
            //this.dataGridView1.DataSource = tickets;
            //oleDbConnection.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox1.Text == "Bronze")
            {
                this.label7.Text = "500";
            }
            else if (this.comboBox1.Text == "Silver")
            {
                this.label7.Text = "750";
            }
            else
            {
                this.label7.Text = "1000";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerPage customerPage = new CustomerPage();
            customerPage.Show();
            this.Close();
        }
    }
}
