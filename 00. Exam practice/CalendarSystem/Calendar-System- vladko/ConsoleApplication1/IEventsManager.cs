namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;

    public interface IEventsManager
    {
        void AddEvent(Event a);

        int DeleteEventsByTitle(string b);

        IEnumerable<Event> ListEvents(DateTime c, int d);
    }
}
