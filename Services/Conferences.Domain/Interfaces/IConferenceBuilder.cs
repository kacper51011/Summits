using Conferences.Domain.Aggregates;
using Conferences.Domain.Entities;
using Conferences.Domain.Utilities;
using Conferences.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Interfaces
{
    public interface IConferenceBuilder: INameStep, IDescriptionStep, ITicketPoolStep, ILecturesStep, IDatesStep, IBuildStep
    {
        public ErrorType ErrorType { get; set; }
    }
    //string name, string description, TicketPool ticketPool, List<Lecture> lectures, DateTime startDateUtc, DateTime endDateUtc
     public interface INameStep
    {
        public string Name { get; }

        public IDescriptionStep SetName(string name);

    }

    public interface IDescriptionStep
    {
        public string Description { get; set; }
        public ITicketPoolStep SetDescription(string description);

    }

    public interface ITicketPoolStep
    {
        public TicketPool TicketPool { get; set; }

        public ILecturesStep SetTicketPool(TicketPool ticketPool);
    }

    public interface ILecturesStep
    {
        List<Lecture> Lectures { get; set; }

        public IDatesStep SetLectures(List<Lecture> lectures);
    }

    public interface IDatesStep
    {
        public DateTime StartDateTimeUtc { get; set; }
        public DateTime EndDateTimeUtc { get; set; }
        public IBuildStep SetDates(DateTime startDateTimeUtc, DateTime endDateTimeUtc);

    }

    public interface IBuildStep
    {
        public Result<Conference> Build();
    }
}
