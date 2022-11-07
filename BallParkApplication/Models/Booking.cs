using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallParkApplication.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public int TicketId { get; set; }

        public int CustomerId  { get; set; }

        public string BookingDate { get; set; }
    }
}
