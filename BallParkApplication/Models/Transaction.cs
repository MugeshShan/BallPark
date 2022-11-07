using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallParkApplication.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

        public string TransactionStatus { get; set; }

        public int CustomerId { get; set; }

        public string TransactionDate { get; set; }
    }
}
