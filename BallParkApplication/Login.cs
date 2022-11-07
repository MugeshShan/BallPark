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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Customer> customers = new List<Customer>();
            OleDbConnection oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["BallPark"];


            var command = "Select * from Customer";
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            adapter.SelectCommand = command2;
            var ds = new DataSet();
            adapter.Fill(ds);
            var dt = ds.Tables[0];
            foreach (DataRow dr in dt.Rows)
            {

                var tempUser = new Customer
                {
                    Id = Convert.ToInt32(dr["Customer_Id"]),
                    Username = dr["Username"].ToString(),
                    Password = dr["Password"].ToString()
                };
                if (tempUser != null)
                {
                    customers.Add(tempUser);
                }
            }

            foreach(var cust in customers)
            {
                if(textBox1.Text == cust.Username && maskedTextBox1.Text == cust.Password)
                {
                    MessageBox.Show("Welcome " + cust.Username + "!!!");
                    Utility.Utility.Customer = cust;
                    BookingPage page = new BookingPage();
                    page.Show();
                    this.Close();
                }
            }
        }
            
    }
}
