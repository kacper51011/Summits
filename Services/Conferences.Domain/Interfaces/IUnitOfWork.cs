using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        // for changes coming from event store
        public Task SaveChangesAsync();

        // for changes which will be send to event store
        public Task SaveChangesAsyncAndNotify();

    }
}
