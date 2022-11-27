using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallParkApplication.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }

        public int TicketNo { get; set; }

        public int Price { get; set; }

        public int SeatId { get; set; }

        public int CustomerId { get; set; }

        public string Date { get; set; }
    }
}
