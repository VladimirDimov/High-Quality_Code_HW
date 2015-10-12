namespace CalendarSystem.Commands
{
    public interface ICommand
    {
        string Execute(IEventsManager eventsManager, string[] parametres);
    }
}
