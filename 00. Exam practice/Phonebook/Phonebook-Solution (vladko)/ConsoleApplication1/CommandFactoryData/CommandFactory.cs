namespace Phonebook.CommandFactoryData
{
    using System;
    using Phonebook.Commands;

    public class CommandFactory : ICommandFactory
    {
        public ICommand GetCommand(string commandName, string[] inputParameters)
        {
            if (commandName.StartsWith("AddPhone") && (inputParameters.Length >= 2))
            {
                return new AddPhoneCommand();
            }
            else if ((commandName == "ChangePhone") && (inputParameters.Length == 2))
            {
                return new ChangePhoneCommand();
            }
            else if ((commandName == "List") && (inputParameters.Length == 2))
            {
                return new ListPhonesCommand();
            }
            else
            {
                throw new ArgumentException("Invalid command");
            }
        }
    }
}
