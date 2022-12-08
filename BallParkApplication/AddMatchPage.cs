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
    public partial class AddMatchPage : Form
    {
        public AddMatchPage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["BallPark"];


            oleDbConnection.Open();
            var command = String.Format("Select * from MatchDetails");
            OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = command2;
            var ds = new DataSet();
            adapter.Fill(ds);
            var dt = ds.Tables[0];
            var Matches = new List<Match>();
            foreach (DataRow dr in dt.Rows)
            {

                var tempUser = new Match
                {
                    Id = Convert.ToInt32(dr["ID"]),
                    MatchName = dr["MatchName"].ToString(),
                    TeamA = dr["TeamA"].ToString(),
                    TeamB = dr["TeamB"].ToString(),
                    Date = dr["Match_Date"].ToString()
                };
                if (tempUser != null)
                {
                    Matches.Add(tempUser);
                }

            }

            var finalMatches = Matches.FindAll(x => x.Date == this.dateTimePicker1.Text).ToList();
            this.dataGridView1.DataSource = finalMatches;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["BallPark"];
            oleDbConnection.Open();
            var command = String.Format("Insert INTO [MatchDetails] ([MatchName], [TeamA], [TeamB], [Match_Date]) VALUES ('{0}', '{1}', '{2}', '{3}')", textBox1.Text, textBox2.Text, textBox3.Text, dateTimePicker2.Text);
            OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            command2.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AdminPage adminPage = new AdminPage();
            adminPage.Show();
            this.Close();
        }
    }
}
