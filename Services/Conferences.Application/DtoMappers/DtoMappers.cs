using Conferences.Application.Dto;
using Conferences.Domain.Aggregates;
using Conferences.Domain.Entities;
using Conferences.Domain.ValueObjects;

namespace Conferences.Application.DtoMappers
{
    public static class DtoMappers
    {

        public static TicketPool MapToTicketPool(this TicketPoolDto dto)
        {
            return new TicketPool()
            {
                BasicTicketPriceEur = dto.BasicTicketPriceEur,
                VipTicketPriceEur = dto.VipTicketPriceEur,
                BasicTicketsPool = dto.BasicTicketsPool,
                VipTicketsPool = dto.VipTicketsPool
            };

        }
        public static List<Lecture> MapToLectures(this List<LectureDto> dto)
        {
            var lectures = new List<Lecture>();
            foreach (var item in dto)
            {
                var itemToAdd = new Lecture()
                {
                    SpeakerId = item.SpeakerId,
                    StartTimeUtc = item.StartTimeUtc,
                    EndTimeUtc = item.EndTimeUtc,
                    Description = item.Description,
                    Thema = item.Thema
                };
                lectures.Add(itemToAdd);
            }
            return lectures;
        }
    }
}
