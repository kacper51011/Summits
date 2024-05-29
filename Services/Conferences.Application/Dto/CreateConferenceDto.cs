using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Application.Dto
{
    public class CreateConferenceDto
    {
        public string Name {  get; set; }
            public string Description { get; set; }
            public TicketPoolDto ticketPool { get; set; }
            public List<LectureDto> lectures {  get; set; }
            public DateTime startDateUtc { get; set; }
            public DateTime endDateUtc { get; set; }
    }

    public class TicketPoolDto
    {
        public int VipTicketsPool { get; set; }
        public int BasicTicketsPool { get; set; }
        public decimal VipTicketPriceEur { get; set; }
        public decimal BasicTicketPriceEur { get; set; }
    }

    public class LectureDto
    {
        public DateTime StartTimeUtc { get; set; }
        public DateTime EndTimeUtc { get; set; }
        public string Thema { get; set; }
        public string Description { get; set; }
        public string SpeakerId { get; set; }
    }
}
