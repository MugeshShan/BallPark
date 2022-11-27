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
    public partial class MyBookingsPage : Form
    {
        public MyBookingsPage()
        {
            InitializeComponent();
        }

        private void MyBookingsPage_Load(object sender, EventArgs e)
        {
            OleDbConnection oleDbConnection;
            oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["BallPark"];
            oleDbConnection.Open();
            var command = String.Format("Select * from Ticket");
            OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = command2;
            var ds = new DataSet();
            adapter.Fill(ds);
            var dt = ds.Tables[0];
            List<Ticket> tickets = new List<Ticket>();
            foreach (DataRow dr in dt.Rows)
            {
                var ticket = new Ticket
                {
                    TicketId = Convert.ToInt32(dr["Ticket_Id"]),
                    TicketNo = Convert.ToInt32(dr["Ticket_No"]),
                    Price = Convert.ToInt32(dr["Price"]),
                    SeatId = Convert.ToInt32(dr["SeatId"]),
                    Date = dr["Ticket_Date"].ToString(),
                    CustomerId = Convert.ToInt32(dr["Cid"])
                };

                if (ticket.CustomerId == Utility.Utility.Customer.Cid)
                {
                    tickets.Add(ticket);
                }
            }
            this.dataGridView1.DataSource = tickets;
            oleDbConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerPage customerPage = new CustomerPage();
            customerPage.Show();
            this.Close();
        }
    }
}
