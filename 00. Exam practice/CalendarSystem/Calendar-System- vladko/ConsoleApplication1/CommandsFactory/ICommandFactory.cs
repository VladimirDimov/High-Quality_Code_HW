namespace CalendarSystem.CommandsFactory
{
    using CalendarSystem.Commands;

    public interface ICommandFactory
    {
        ICommand GetCommand(string comamndName);
    }
}
