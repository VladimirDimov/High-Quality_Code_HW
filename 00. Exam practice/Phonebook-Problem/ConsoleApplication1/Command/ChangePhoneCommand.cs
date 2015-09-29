namespace ConsoleApplication1.Command
{
    using ConsoleApplication1.PhoneFormaters;
    using ConsoleApplication1.Printer;
    using System.Text;

    class ChangePhoneCommand : ICommand
    {
        private IPhoneFormater phoneFormatter = new PhoneStringBuilderFormater();
        private StringBuilder output;
        private IPhonebookRepository data;
        private IPrinter printer;

        public ChangePhoneCommand(StringBuilder output, IPhonebookRepository data, IPrinter printer)
        {
            this.output = output;
            this.data = data;
            this.printer = printer;
        }

        public void Execute(string[] parameters)
        {
            this.printer.Print("" + data.ChangePhone(this.phoneFormatter.Format(parameters[0], this.output), this.phoneFormatter.Format(parameters[1], this.output)) + " numbers changed");
        }
    }
}
