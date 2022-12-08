using BallParkApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallParkApplication.Utility
{
    public static class Utility
    {
        public static Customer Customer = new Customer();
        public static string Section = "";
        public static double Amount = 0;
        public static int No_of_Seats = 0;
        public static Match Match = new Match();
        public static double FinalPrice = 0.0;
        public static List<Match> Matches = new List<Match>();
    }
}
