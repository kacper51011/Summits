using Conferences.Domain.Aggregates;
using Conferences.Domain.Interfaces;
using Conferences.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Infrastructure.Repositories
{
    public class ConferenceRepository : IConferenceRepository
    {
        private readonly ApplicationDbContext _context;
        public ConferenceRepository(ApplicationDbContext context)
        {
            
            _context = context;
        }
        public async Task CreateOrUpdateConference(Conference conference)
        {
            await _context.Conferences.AddAsync(conference);
        }

        public async Task<List<Conference>> GetAllConferences()
        {
            return await _context.Conferences.ToListAsync();
        }

        public async Task<Conference?> GetConferenceById(string conferenceId)
        {
            return await _context.Conferences.FirstOrDefaultAsync(x => x.ConferenceId == conferenceId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
