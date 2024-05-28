using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.ValueObjects
{
    public class TicketPool
    {
        public int VipTicketsPool { get; set; }
        public int BasicTicketsPool { get; set; }
        public decimal VipTicketPriceEur { get; set; }
        public decimal BasicTicketPriceEur { get; set; }


    }
}
