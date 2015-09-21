using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge
{
    public class BlueConsole : ConsoleSettings
    {
        private ConsoleColor currentConsoleColor;

        public override void Apply()
        {
            this.currentConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public override void Cancel()
        {
            Console.ForegroundColor = currentConsoleColor;
        }
    }
}
