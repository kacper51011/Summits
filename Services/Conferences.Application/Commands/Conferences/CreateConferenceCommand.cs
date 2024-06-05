using Conferences.Application.Dto;
using Conferences.Application.Mappers;
using Conferences.Domain.Aggregates;
using Conferences.Domain.Builders;
using Conferences.Domain.Errors;
using Conferences.Domain.Utilities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Application.Commands.Conferences
{
    public record CreateConferenceCommand(CreateConferenceDto Dto): IRequest<Result<string>>
    {
    }

    public class CreateConferenceCommandHandler : IRequestHandler<CreateConferenceCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateConferenceCommand request, CancellationToken cancellationToken)
        {
            Result<Conference> result = ConferenceBuilder.Create()
                .SetName(request.Dto.Name)
                .SetDescription(request.Dto.Description)
                .SetTicketPool(request.Dto.TicketPool.MapToTicketPool())
                .SetLectures(request.Dto.Lectures.MapToLectures())
                .SetDates(request.Dto.StartDateUtc, request.Dto.EndDateUtc)
                .Build();

            if (result.IsSuccess)
            {
                return Result.Success(result.Data!.ConferenceId);
            }
            else
            {
                return Result.Failure<string>(result.Error);
            }
        }
    }
}
