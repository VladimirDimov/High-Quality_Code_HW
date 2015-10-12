namespace CalendarSystem.Commands
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class ListEventsCommand : ICommand
    {
        public string Execute(IEventsManager eventsManager, string[] parametres)
        {
            var d = DateTime.ParseExact(parametres[0], "yyyy-MM-ddTHH:mm:ss", CultureInfo.InvariantCulture);
            var c = int.Parse(parametres[1]);
            var events = eventsManager.ListEvents(d, c).ToList();
            var sb = new StringBuilder();

            if (!events.Any())
            {
                return "No events found";
            }

            foreach (var e in events)
            {
                sb.AppendLine(e.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
