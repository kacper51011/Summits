using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.ValueObjects
{
    public class TicketPool
    {
        public int VipTicketsPool { get; private set; }
        public int VipTicketsSold { get; private set; }
        public int BasicTicketsPool { get; private set; }
        public int BasicTicketsSold { get; private set; }
        public decimal VipTicketPriceEur { get; private set; }
        public decimal BasicTicketPriceEur { get; private set; }


    }
}
