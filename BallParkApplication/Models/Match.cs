using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallParkApplication.Models
{
    public class Match
    {
        public int Id { get; set; }

        public string MatchName { get; set; }

        public string TeamA { get; set; }

        public string TeamB { get; set; }

        public string Date { get; set; }
    }
}
