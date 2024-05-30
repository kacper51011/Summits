using Conferences.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conferences.Domain
{
    public abstract class AggregateRoot
    {
        public List<BaseEvent> ChangesNotCommitedToEventStore { get; private set; } = new List<BaseEvent>();
        public List<BaseEvent> ChangesCommitedToEventStore { get; private set; } = new List<BaseEvent>();

        // set to -1 because state is not initialized
        public int Version { get; set; } = -1;



        // will be needed when sending changes to event store
        public void MarkChangesAsCommited()
        {
            ChangesCommitedToEventStore.AddRange(ChangesNotCommitedToEventStore);
            ChangesNotCommitedToEventStore.Clear();
        }

        protected void ApplyChangeToAggregate(BaseEvent eventToApply, bool isNew)
        {
            dynamic dynamicThis = this;
            dynamicThis.Apply(eventToApply);

            if (isNew)
            {
                ChangesNotCommitedToEventStore = new List<BaseEvent>();
            }

        }

        public void ApplyNewChange(BaseEvent eventToApply) {
            ApplyChangeToAggregate(eventToApply, true);
        }

        public void ApplyChangeFromEventStore(BaseEvent eventToApply)
        {
            ApplyChangeToAggregate(eventToApply, false);
        }

        public void ReplayChanges(IEnumerable<BaseEvent> changes)
        {
            foreach (var change in changes)
            {
                ApplyChangeToAggregate(change, false);
            }
        }

    }
}
