using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Entities
{
    public class Lecture
    {
        public DateTime StartTimeUtc { get; set; }
        public DateTime EndTimeUtc { get; set; }
        public string Thema { get; set; }
        public string Description { get; set; }
        public string Speaker { get; set; }
        
    }


}
