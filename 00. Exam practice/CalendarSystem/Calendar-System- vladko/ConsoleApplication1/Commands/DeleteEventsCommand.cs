namespace CalendarSystem.Commands
{
    using System;

    public class DeleteEventsCommand : ICommand
    {
        public string Execute(IEventsManager eventsManager, string[] parametres)
        {
            if (parametres.Length != 1)
            {
                throw new ArgumentException("Invalid number of parametres!");
            }

            int numberOfDeletedEvents = eventsManager.DeleteEventsByTitle(parametres[0]);

            if (numberOfDeletedEvents == 0)
            {
                return "No events found.";
            }

            return numberOfDeletedEvents + " events deleted";
        }
    }
}
