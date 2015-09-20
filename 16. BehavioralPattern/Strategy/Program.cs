using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        static void Main()
        {
            var message = new Message("Hello!");

            message.Printer = new DefaultPrinter();
            message.Print();

            message.Printer = new RedPrinter();
            message.Print();

            message.Printer = new BluePrinter();
            message.Print();
        }
    }
}
