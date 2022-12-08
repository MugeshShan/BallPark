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
    public partial class PaymentPage : Form
    {
        public PaymentPage()
        {
            InitializeComponent();
        }

        private void PaymentPage_Load(object sender, EventArgs e)
        {
            this.label9.Text = Utility.Utility.Section;
            this.label10.Text = Utility.Utility.No_of_Seats.ToString();
            this.label11.Text = Utility.Utility.FinalPrice.ToString();
            this.label3.Text = Utility.Utility.Match.Date;
            this.label2.Text = Utility.Utility.Match.MatchName;
            var paymentType = new List<string>();
            paymentType.Add("Credit Card");
            paymentType.Add("Debit Card");
            paymentType.Add("PayPal");
            this.comboBox1.DataSource = paymentType;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["BallPark"];
            oleDbConnection.Open();
            
            var command = String.Format("Insert INTO [Payment] ([Amount], [Payment_Type], [Customer_Id], [Payment_Date]) VALUES ({0}, '{1}', {2}, '{3}')", Utility.Utility.FinalPrice, this.comboBox1.Text, Utility.Utility.Customer.Id, DateTime.Now.ToString("MM/dd/yyyy"));
            var command2 = new OleDbCommand(command, oleDbConnection);
            command2.ExecuteNonQuery();
            command = String.Format("Insert INTO [Transaction] ([Transaction_Status], [Customer_Id], [Transaction_Date]) VALUES ('{0}', {1}, '{2}')", "Success", Utility.Utility.Customer.Cid, DateTime.Now.ToString("MM/dd/yyyy"));
            command2 = new OleDbCommand(command, oleDbConnection);
            command2.ExecuteNonQuery();
            command = "SELECT TOP 1 * FROM Customer ORDER BY Cid DESC";

            OleDbDataAdapter adapter = new OleDbDataAdapter();
            command2 = new OleDbCommand(command, oleDbConnection);
            adapter.SelectCommand = command2;
            var ds = new DataSet();
            adapter.Fill(ds);
            var dt = ds.Tables[0];
            var id = dt.Rows[0]["Cid"];
            command = String.Format("Insert INTO [Booking] ([Ticket_Id], [Customer_Id], [Booking_Date], [Match_Id]) VALUES ({0}, {1}, '{2}', {3})", id, Utility.Utility.Customer.Id, DateTime.Now.ToString("MM/dd/yyyy"), Utility.Utility.Match.Id);
            command2 = new OleDbCommand(command, oleDbConnection);
            command2.ExecuteNonQuery();

            command = "SELECT TOP 1 * FROM Booking ORDER BY Booking_Id DESC";

            adapter = new OleDbDataAdapter();
            command2 = new OleDbCommand(command, oleDbConnection);
            adapter.SelectCommand = command2;
             ds = new DataSet();
            adapter.Fill(ds);
             dt = ds.Tables[0];
             id = dt.Rows[0]["Booking_Id"];
            command = String.Format("Insert INTO [CustomerBooking] ([Booking_Id], [Customer_Id]) VALUES ({0}, {1})", id, Utility.Utility.Customer.Id, DateTime.Now.ToString("MM/dd/yyyy"));
            command2 = new OleDbCommand(command, oleDbConnection);
            command2.ExecuteNonQuery();
            MessageBox.Show("Tickets Booked!!!");
            CustomerPage bookingPage = new CustomerPage();
            bookingPage.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BookingPage bookingPage = new BookingPage();
            bookingPage.Show();
            this.Close();
        }
    }
}
