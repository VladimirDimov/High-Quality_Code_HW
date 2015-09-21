using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    class Program
    {
        static void Main()
        {
            var printerARed = new PrinterA(new RedConsole());
            printerARed.Print("This is printer A in red.");

            var printerBBlue = new PrinterB(new BlueConsole());
            printerBBlue.Print("This is printer B in blue.");

            var printerCDefault = new PrinterC(new DefaultConsole());
            printerCDefault.Print("This is printer C in default color.");
        }
    }
}
