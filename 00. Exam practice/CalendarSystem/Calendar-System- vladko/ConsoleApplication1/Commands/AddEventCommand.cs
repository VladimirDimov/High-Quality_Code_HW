namespace CalendarSystem.Commands
{
    using System;
    using System.Globalization;

    public class AddEventCommand : ICommand
    {
        public string Execute(IEventsManager eventsManager, string[] parametres)
        {
            if (parametres.Length == 2)
            {
                var date = DateTime.ParseExact(parametres[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var e = new Event
                {
                    DateTime = date,
                    Title = parametres[1],
                    Location = null,
                };

                eventsManager.AddEvent(e);

                return "Event added";
            }
            else if (parametres.Length == 3)
            {
                var date = DateTime.ParseExact(parametres[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
                var e = new Event
                {
                    DateTime = date,
                    Title = parametres[1],
                    Location = parametres[2],
                };

                eventsManager.AddEvent(e);

                return "Event added";
            }
            else
            {
                throw new ArgumentException("Invalid number of parametres!");
            }
        }
    }
}
