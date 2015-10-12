namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class EventsManagerFast : IEventsManager
    {
        private readonly MultiDictionary<string, Event> eventsByTitle = new MultiDictionary<string, CalendarSystem.Event>(true);
        private readonly OrderedMultiDictionary<DateTime, Event> eventsOrderedByDate = new OrderedMultiDictionary<DateTime, Event>(true);

        public void AddEvent(Event eventToAdd)
        {
            string eventTitleToLower = eventToAdd.Title.ToLowerInvariant();
            this.eventsByTitle.Add(eventTitleToLower, eventToAdd);
            this.eventsOrderedByDate.Add(eventToAdd.DateTime, eventToAdd);
        }

        public int DeleteEventsByTitle(string title)
        {
            string titleToLower = title.ToLowerInvariant();
            var eventsToDelete = this.eventsByTitle[titleToLower];
            int numberOfEventsToDelete = eventsToDelete.Count;

            foreach (var ev in eventsToDelete)
            {
                this.eventsOrderedByDate.Remove(ev.DateTime, ev);
            }

            this.eventsByTitle.Remove(titleToLower);

            return numberOfEventsToDelete;
        }

        public IEnumerable<Event> ListEvents(DateTime startDateTime, int numberOfEvents)
        {
            var dateTime =
                from e in this.eventsOrderedByDate.RangeFrom(startDateTime, true).Values
                select e;

            var events = dateTime.Take(numberOfEvents);

            return events;
        }
    }
}