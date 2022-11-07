using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallParkApplication.Models
{
    public class CustomerInfo : Customer
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string State { get; set; }
    }
}
