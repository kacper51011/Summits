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

        [HttpGet]

        public async Task<ActionResult<List<GetConferenceResponseDto>>> GetAllConferences()
        {
            return Ok();
        }

        [HttpGet("{conferenceId}")]

        public async Task<ActionResult<GetConferenceResponseDto>> GetConferenceById(string conferenceId)
        {
            return Ok();
        }

        [HttpPost("{conferenceId}/AddNewTickets")]
        public async Task<ActionResult> AddNewTicketsToConferenceTicketPool(string conferenceId, ExtendTicketsPoolDto addTicketsDto)
        {
            return Ok();
        }

        [HttpPost("{conferenceId}/EndConference")]
        public async Task<ActionResult> EndConference(string conferenceId)
        {
            return Ok();
        }

        [HttpPost("{conferenceId}/CancelConference")]
        public async Task<ActionResult> CancelConference(string conferenceId)
        {
            return Ok();
        }

        [HttpPost("{conferenceId}/OpenTicketPool")]
        public async Task<ActionResult> OpenTicketPool(string conferenceId)
        {
            return Ok();
        }

        [HttpPost("{conferenceId}/CloseTicketPool")]
        public async Task<ActionResult> CloseTicketPool(string conferenceId)
        {
            return Ok();
        }

    }
}
