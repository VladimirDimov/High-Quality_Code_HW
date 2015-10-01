namespace ConsoleApplication1.Command
{
    using ConsoleApplication1.PhoneFormaters;
    using ConsoleApplication1.Printer;
    using System;
    using System.Collections.Generic;
    using System.Text;

    class ListCommand : ICommand
    {
        private IPhoneFormater phoneFormatter = new PhoneStringBuilderFormater();
        private StringBuilder output;
        private IPhonebookRepository data;
        private IPrinter printer;

        public ListCommand(StringBuilder output, IPhonebookRepository data, IPrinter printer)
        {
            this.output = output;
            this.data = data;
            this.printer = printer;
        }

        public void Execute(IList<string> parameters)
        {
            try
            {
                IEnumerable<Entry> entries = data.ListEntries(int.Parse(parameters[0]), int.Parse(parameters[1]));

                foreach (var entry in entries)
                {
                    this.printer.Print(entry.ToString());
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                this.printer.Print("Invalid range");
            }
        }
    }
}
