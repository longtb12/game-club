using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PlayStudios.Data;
using PlayStudios.DTOs;
using PlayStudios.Models;

namespace PlayStudios.Services
{
    public interface IClubService
    {
        Task<ClubDto> CreateClub(CreateClubDto club);
        Task<List<ClubDto>> GetAllClubs(string? search);
    }

    public class ClubService : IClubService
    {
        private readonly GameClubContext _context;

        private readonly IMapper _mapper;

        public ClubService(GameClubContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClubDto> CreateClub(CreateClubDto club)
        {
            // Check for duplicates
            if (_context.Clubs.Any(c => c.Name == club.Name))
                throw new InvalidOperationException("A club with the same name already exists.");

            var newClub = new GameClub()
            {
                Name = club.Name,
                Description = club.Description
            };

            _context.Clubs.Add(newClub);
            await _context.SaveChangesAsync();

            return _mapper.Map<ClubDto>(newClub);
        }

        public async Task<List<ClubDto>> GetAllClubs(string? search)
        {
            var clubs = new List<GameClub>();
            if (string.IsNullOrEmpty(search))
            {
                clubs = await _context.Clubs.ToListAsync();
            }
            else
            {
                clubs = await _context.Clubs
                    .Where(c => c.Name.Contains(search) || c.Description.Contains(search))
                    .ToListAsync();
            }

            return _mapper.Map<List<ClubDto>>(clubs);
        }
    }

}
