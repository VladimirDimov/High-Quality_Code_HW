namespace ConsoleApplication1.Command
{
    using ConsoleApplication1.PhoneFormaters;
    using ConsoleApplication1.Printer;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class AddPhoneCommand : ICommand
    {
        private IPhoneFormater phoneFormatter = new PhoneStringBuilderFormater();
        private StringBuilder output;
        private IPhonebookRepository data;
        private IPrinter printer;

        public AddPhoneCommand(StringBuilder output, IPhonebookRepository data, IPrinter printer)
        {
            this.output = output;
            this.data = data;
            this.printer = printer;
        }

        public void Execute(IList<string> parameters)
        {
            string name = parameters[0];
            var phoneNumbers = parameters.Skip(1).ToList();

            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                phoneNumbers[i] = phoneFormatter.Format(phoneNumbers[i], output);
            }

            bool flag = data.AddPhone(name, phoneNumbers);

            if (flag)
            {
                this.printer.Print("Phone entry created.");
            }
            else
            {
                this.printer.Print("Phone entry merged");
            }

        }
    }
}
