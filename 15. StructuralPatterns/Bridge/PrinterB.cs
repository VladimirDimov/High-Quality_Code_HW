using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge
{
    public class PrinterB : Printer
    {
        public PrinterB(ConsoleSettings consoleSettings)
            :base(consoleSettings)
        {
        }

        public override void Print(string message)
        {
            base.consoleSettings.Apply();
            Console.WriteLine("### " + message + " ###");
            base.consoleSettings.Cancel();

        }
    }
}
