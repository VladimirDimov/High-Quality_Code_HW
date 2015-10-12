namespace CalendarSystem.CommandParserData
{
    public interface ICommandParser
    {
        CommandInfo Parse(string commandText);
    }
}
