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
            public TicketPoolDto TicketPool { get; set; }
            public List<LectureDto> Lectures {  get; set; }
            public DateTime StartDateUtc { get; set; }
            public DateTime EndDateUtc { get; set; }
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
