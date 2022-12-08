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
    public partial class MatchPage : Form
    {
        OleDbConnection oleDbConnection;
        List<Match> Matches;
        public MatchPage()
        {
            InitializeComponent();
            
        }

        private void MatchPage_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oleDbConnection = new OleDbConnection();
            oleDbConnection.ConnectionString = ConfigurationManager.AppSettings["BallPark"];
            oleDbConnection.Open();
            var command = String.Format("Select * from MatchDetails");
            OleDbCommand command2 = new OleDbCommand(command, oleDbConnection);
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = command2;
            var ds = new DataSet();
            adapter.Fill(ds);
            var dt = ds.Tables[0];
            Matches = new List<Match>();
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
            Utility.Utility.Matches.AddRange(Matches);
            List<string> MatchNames = new List<string>();

            foreach(var match in Matches)
            {
                if(match.Date == this.dateTimePicker1.Text)
                {
                    MatchNames.Add(match.MatchName);
                }
            }

            this.comboBox1.DataSource = MatchNames;
            oleDbConnection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var match = Matches.Find(x => x.MatchName == this.comboBox1.Text);
            Utility.Utility.Match = match;
            BookingPage customerPage = new BookingPage();
            customerPage.Show();
            this.Close();
        }
    }
}
