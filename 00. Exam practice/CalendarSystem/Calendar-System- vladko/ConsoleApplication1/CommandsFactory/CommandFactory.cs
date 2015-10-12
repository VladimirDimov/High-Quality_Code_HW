namespace CalendarSystem.CommandsFactory
{
    using System;
    using CalendarSystem.Commands;

    public class CommandFactory : ICommandFactory
    {
        public Commands.ICommand GetCommand(string commandName)
        {
            ICommand command;
            if (commandName == "AddEvent")
            {
                command = new AddEventCommand();
            }
            else if (commandName == "AddEvent")
            {
                command = new AddEventCommand();
            }
            else if (commandName == "DeleteEvents")
            {
                command = new DeleteEventsCommand();
            }
            else if (commandName == "ListEvents")
            {
                command = new ListEventsCommand();
            }
            else
            {
                throw new ArgumentException("Invalid comamnd name!");
            }

            return command;
        }
    }
}
