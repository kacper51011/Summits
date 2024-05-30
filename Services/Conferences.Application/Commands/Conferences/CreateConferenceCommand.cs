using Conferences.Application.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Application.Commands.Conferences
{
    public record CreateConferenceCommand(CreateConferenceDto Dto): IRequest
    {
    }

    public class CreateConferenceCommandHandler : IRequestHandler<CreateConferenceCommand>
    {
        public async Task Handle(CreateConferenceCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
