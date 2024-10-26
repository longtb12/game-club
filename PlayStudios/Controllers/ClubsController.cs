using Microsoft.AspNetCore.Mvc;
using PlayStudios.DTOs;
using PlayStudios.Services;

namespace PlayStudios.Controllers
{
    [Route("api/clubs")]
    [ApiController]
    public class ClubsController : ControllerBase
    {
        private readonly IClubService _clubService;

        public ClubsController(IClubService clubService)
        {
            _clubService = clubService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClub([FromBody] CreateClubDto club)
        {
            try
            {
                var createdClub = await _clubService.CreateClub(club);
                return CreatedAtAction(nameof(CreateClub), new { id = createdClub.Id }, createdClub);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClubDto>>> GetClubs([FromQuery] string? search)
        {
            var clubs = await _clubService.GetAllClubs(search);
            return Ok(clubs);
        }
    }
}
