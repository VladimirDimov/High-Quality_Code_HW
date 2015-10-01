using ConsoleApplication1.Printer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1.Command.CommandFactory
{
    class CommandFactory : ICommandFactory
    {
        private AddPhoneCommand addPhoneCommand;
        private ChangePhoneCommand changePhoneCommand;
        private ListCommand listCommand;

        private StringBuilder output;
        private IPhonebookRepository data;
        private IPrinter printer;

        public CommandFactory(StringBuilder output, IPhonebookRepository data, IPrinter printer)
        {
            this.output = output;
            this.data = data;
            this.printer = printer;
        }

        public ICommand CreateCommand(string name)
        {
            ICommand command;
            if (name == "AddPhone")
            {
                command = new AddPhoneCommand(this.output, this.data, this.printer);
            }
            else if (name == "ChangePhone")
            {
                command = new ChangePhoneCommand(this.output, this.data, this.printer);
            }
            else if (name == "List")
            {
                command = new ListCommand(this.output, this.data, this.printer);
            }
            else
            {
                throw new ArgumentException("Invalid Command name!");
            }

            return command;
        }
    }
}
