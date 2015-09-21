using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bridge
{
    public class RedConsole : ConsoleSettings
    {
        private ConsoleColor currentConsoleColor;

        public override void Apply()
        {
            this.currentConsoleColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public override void Cancel()
        {
            Console.ForegroundColor = currentConsoleColor;
        }
    }
}
