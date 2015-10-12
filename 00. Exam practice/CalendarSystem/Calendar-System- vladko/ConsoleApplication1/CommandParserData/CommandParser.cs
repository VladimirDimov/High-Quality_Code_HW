namespace CalendarSystem.CommandParserData
{
    using System;

    public class CommandParser : ICommandParser
    {
        public CommandInfo Parse(string commandText)
        {
            int whiteSpaceIndex = commandText.IndexOf(' ');
            if (whiteSpaceIndex == -1)
            {
                throw new ArgumentException("Invalid command: " + commandText);
            }

            string name = commandText.Substring(0, whiteSpaceIndex);
            string argumentsText = commandText.Substring(whiteSpaceIndex + 1);

            var commandArguments = argumentsText.Split('|');
            for (int i = 0; i < commandArguments.Length; i++)
            {
                argumentsText = commandArguments[i];
                commandArguments[i] = argumentsText.Trim();
            }

            var command = new CommandInfo(name, commandArguments);

            return command;
        }
    }
}
