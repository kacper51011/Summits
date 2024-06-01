using Conferences.Domain.Entities;
using Conferences.Domain.Interfaces;
using Conferences.Domain.Utilities;
using Conferences.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Builders
{
    public class ConferenceBuilder : IConferenceBuilder
    {
        public ErrorType ErrorType { get; set; } = ErrorType.None;

        public string Name { get; set; }

        public string Description { get; set; }
        public TicketPool TicketPool {  get; set; }
        public List<Lecture> Lectures { get; set; } = new List<Lecture>();

        public static IConferenceBuilder Create()
        {
            throw new NotImplementedException();
        }

        public ITicketPoolStep SetDescription(string description)
        {
            throw new NotImplementedException();
        }

        public IDatesStep SetLectures(List<Lecture> lectures)
        {
            throw new NotImplementedException();
        }

        public IDescriptionStep SetName(string name)
        {
            throw new NotImplementedException();
        }

        public ILecturesStep SetTicketPool(TicketPool ticketPool)
        {
            throw new NotImplementedException();
        }
    }
}
