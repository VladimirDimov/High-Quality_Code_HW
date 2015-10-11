namespace Phonebook.CommandFactoryData
{
    using Phonebook.Commands;

    public interface ICommandFactory
    {
        ICommand GetCommand(string commandName, string[] inputParameters);
    }
}
