using Conferences.Domain.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Interfaces
{
    public interface IConferenceRepository
    {
        public Task<List<Conference>> GetAllConferences();
        public Task<Conference?> GetConferenceById(string conferenceId);
        public Task CreateOrUpdateConference(Conference conference);

        public Task SaveChangesAsync();


        
    }
}
