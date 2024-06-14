using EventStore.Core.Interfaces;
using EventStore.Core.Models;

namespace EventStore.Core.Utils
{
    public class EventTypeFinder : IEventTypeFinder
    {
        public Dictionary<string, Type> EventTypes { get; set; }
        public EventTypeFinder()
        {
            EventTypes = new Dictionary<string, Type>();
            foreach (var domain in AppDomain.CurrentDomain.GetAssemblies())
            {
                var assemblyTypes = domain.GetTypes().Where(x => x.IsSubclassOf(typeof(EventModel)));

                foreach (var item in assemblyTypes)
                {
                    EventTypes.TryAdd(item.Name, item);
                }

            }

        }
        public Type? GetTypeOfEvent(string eventType)
        {
            var type = EventTypes.TryGetValue(eventType, out var result);
            if (!type)
            {
                return null;
            }

            return result;

        }
    }
}
