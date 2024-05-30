using Conferences.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Conferences.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConferencesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ConferencesController(IMediator mediator)
        {
            _mediator = mediator;
            
        }

        [HttpPost]
        public async Task<ActionResult> CreateConference(CreateConferenceDto createConferenceDto)
        {
            return Ok();
        }
    }
}
