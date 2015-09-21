using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge
{
    public abstract class Printer
    {
        protected readonly ConsoleSettings consoleSettings;

        public Printer(ConsoleSettings consoleSettings)
        {
            this.consoleSettings = consoleSettings;
        }

        public abstract void Print(string message);
    }
}
