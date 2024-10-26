using Microsoft.AspNetCore.Mvc;
using PlayStudios.DTOs;
using PlayStudios.Services;

namespace PlayStudios.Controllers
{
    [Route("api/clubs/{clubId}/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventsController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEvent(int clubId, [FromBody] EventDto clubEvent)
        {
            try
            {
                //Basic validate required fields
                if (string.IsNullOrEmpty(clubEvent.Title))
                {
                    return BadRequest("Title is required!");
                }

                var createdEvent = await _eventService.CreateEvent(clubId, clubEvent);
                return CreatedAtAction(nameof(CreateEvent), new { clubId = clubId }, createdEvent);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEventsByClubId(int clubId)
        {
            var events = await _eventService.GetEventsByClubId(clubId);
            return Ok(events);
        }
    }
}
