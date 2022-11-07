using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallParkApplication.Models
{
    public class Payment
    {
        public int PaymentId { get; set; }

        public int CustomerId { get; set; }

        public string PaymentType { get; set; }

        public int Amount { get; set; }
        public string PaymentDate { get; set; }
    }
}
