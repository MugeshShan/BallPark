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
    public partial class AdminPage : Form
    {
        OleDbConnection oleDbConnection;
        OleDbCommand command2;
        public AdminPage()
        {
            oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["BallPark"];
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Booking> payments = new List<Booking>();
            oleDbConnection.Open();
            var command = "Select * from Booking";
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            var command2 = new OleDbCommand(command, oleDbConnection);
            adapter.SelectCommand = command2;
            var ds = new DataSet();
            adapter.Fill(ds);
            var dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {

                var tempUser = new Booking
                {
                    BookingId = Convert.ToInt32(dr["Booking_Id"]),
                    CustomerId = Convert.ToInt32(dr["Customer_Id"]),
                    TicketId = Convert.ToInt32(dr["Ticket_Id"]),
                    BookingDate = dr["Booking_Date"].ToString()
                };
                if (tempUser != null)
                {
                    payments.Add(tempUser);
                }
            }
            this.dataGridView1.DataSource = payments;
            oleDbConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Transaction> payments = new List<Transaction>();
            oleDbConnection.Open();
            var command = "Select * from Transaction";
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            var command2 = new OleDbCommand(command, oleDbConnection);
            adapter.SelectCommand = command2;
            var ds = new DataSet();
            adapter.Fill(ds);
            var dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {

                var tempUser = new Transaction
                {
                    TransactionId = Convert.ToInt32(dr["Transaction_Id"]),
                    CustomerId = Convert.ToInt32(dr["Customer_Id"]),
                    TransactionStatus = dr["Transaction_Status"].ToString(),
                    TransactionDate = dr["Transaction_Date"].ToString()
                };
                if (tempUser != null)
                {
                    payments.Add(tempUser);
                }
            }
            this.dataGridView1.DataSource = payments;
            oleDbConnection.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List<Payment> payments = new List<Payment>();
            oleDbConnection.Open();
            var command = "Select * from Payment";
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            var command2 = new OleDbCommand(command, oleDbConnection);
            adapter.SelectCommand = command2;
            var ds = new DataSet();
            adapter.Fill(ds);
            var dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {

                var tempUser = new Payment
                {
                    PaymentId = Convert.ToInt32(dr["Payment_Id"]),
                    CustomerId = Convert.ToInt32(dr["Customer_Id"]),
                    Amount = Convert.ToInt32(dr["Amount"]),
                    PaymentType = dr["Payment_Type"].ToString(),
                    PaymentDate = dr["Payment_Date"].ToString()
                };
                if (tempUser != null)
                {
                    payments.Add(tempUser);
                }
            }
            this.dataGridView1.DataSource = payments;
            oleDbConnection.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<Ticket> payments = new List<Ticket>();
            oleDbConnection.Open();
            var command = "Select * from Ticket";
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            var command2 = new OleDbCommand(command, oleDbConnection);
            adapter.SelectCommand = command2;
            var ds = new DataSet();
            adapter.Fill(ds);
            var dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {

                var tempUser = new Ticket
                {
                    TicketId = Convert.ToInt32(dr["Ticket_Id"]),
                    Price = Convert.ToInt32(dr["Price"]),
                    TicketNo = Convert.ToInt32(dr["Ticket_No"]),
                    SeatId = Convert.ToInt32(dr["SeatId"])
                };
                if (tempUser != null)
                {
                    payments.Add(tempUser);
                }
            }
            this.dataGridView1.DataSource = payments;
            oleDbConnection.Close();
        }
    }
}
