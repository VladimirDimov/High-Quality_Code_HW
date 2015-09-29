using ConsoleApplication1.Printer;
using System;
namespace ConsoleApplication1.CommandParsers
{
    class CommandParser : ICommandParser
    {
        private ConsolePrinter printer;

        public CommandParser(IPrinter printer)
        {
            this.printer = new ConsolePrinter();
        }

        public ICommandInfo Parse(string input)
        {
            int inputParametersOpenBracketIndex = input.IndexOf('(');

            if (inputParametersOpenBracketIndex == -1)
            {
                Console.WriteLine("error!");
                Environment.Exit(0);
            }

            string commandName = input.Substring(0, inputParametersOpenBracketIndex);

            string commandParametersString = input.Substring(inputParametersOpenBracketIndex + 1, input.Length - inputParametersOpenBracketIndex - 2);

            string[] commandParameters = commandParametersString.Split(',');

            for (int j = 0; j < commandParameters.Length; j++)
            {
                commandParameters[j] = commandParameters[j].Trim();
            }

            return new CommandInfo(commandName, commandParameters);
        }
    }
}
