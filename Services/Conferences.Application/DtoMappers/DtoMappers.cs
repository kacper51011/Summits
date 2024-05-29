using Conferences.Application.Dto;
using Conferences.Domain.Aggregates;
using Conferences.Domain.Entities;
using Conferences.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Application.DtoMappers
{
    public static class DtoMappers
    {
        public static Conference MapToConference(this CreateConferenceDto dto)
        {
            //mapping ticketpool
            var ticketPool = new TicketPool() 
            {
                BasicTicketPriceEur = dto.TicketPool.BasicTicketPriceEur,
                VipTicketPriceEur = dto.TicketPool.VipTicketPriceEur,
                BasicTicketsPool = dto.TicketPool.BasicTicketsPool,
                VipTicketsPool = dto.TicketPool.VipTicketsPool

            };

            //mapping lectures dto
            var lectures = new List<Lecture>();
            foreach (var item in dto.Lectures)
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

            // returning conference/ throwing domainException
            return new Conference(dto.Name, dto.Description, ticketPool, lectures, dto.StartDateUtc, dto.EndDateUtc);
        }
    }
}
