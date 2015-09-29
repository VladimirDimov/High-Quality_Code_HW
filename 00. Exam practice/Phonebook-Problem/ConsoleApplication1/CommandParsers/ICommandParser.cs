namespace ConsoleApplication1.CommandParsers
{
    interface ICommandParser
    {
        ICommandInfo Parse(string input);
    }
}
