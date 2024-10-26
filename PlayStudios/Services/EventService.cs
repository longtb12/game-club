using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PlayStudios.Data;
using PlayStudios.DTOs;
using PlayStudios.Models;

namespace PlayStudios.Services
{
    public interface IEventService
    {
        Task<EventDto> CreateEvent(int clubId, EventDto clubEvent);
        Task<IEnumerable<EventDto>> GetEventsByClubId(int clubId);
    }

    public class EventService : IEventService
    {
        private readonly GameClubContext _context;
        private readonly IMapper _mapper;

        public EventService(GameClubContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EventDto> CreateEvent(int clubId, EventDto clubEvent)
        {
            var club = await _context.Clubs.FindAsync(clubId);
            if (club == null)
                throw new KeyNotFoundException("Club not found.");

            var newClubEvent = new Event()
            {
                Title = clubEvent.Title,
                ClubId = clubId,
                Description = clubEvent.Description,
                ScheduledDateTime = clubEvent.ScheduledDateTime
            };

            _context.Events.Add(newClubEvent);
            await _context.SaveChangesAsync();

            return _mapper.Map<EventDto>(newClubEvent); 
        }
 
        public async Task<IEnumerable<EventDto>> GetEventsByClubId(int clubId)
        {
            var events = await _context.Events.Where(e => e.ClubId == clubId).ToListAsync();
            return _mapper.Map<IEnumerable<EventDto>>(events);
        }
    }
}
