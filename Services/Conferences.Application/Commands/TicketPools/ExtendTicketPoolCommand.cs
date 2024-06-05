using Conferences.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Application.Commands.TicketPools
{
    public record ExtendTicketPoolCommand(string conferenceId, ExtendTicketsPoolDto dto): IRequest;

}
