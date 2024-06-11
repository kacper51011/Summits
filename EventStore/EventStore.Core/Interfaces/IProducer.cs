using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventStore.Core.Interfaces
{
    public interface IProducer
    {
        public Task SendAsync<T>(T message);
    }
}
