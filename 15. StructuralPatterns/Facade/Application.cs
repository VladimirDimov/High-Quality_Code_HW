using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    class Application
    {
        static void Main()
        {
            var gsmControler = new GsmModesControler();
            Console.WriteLine(gsmControler.ToString());

            gsmControler.activateMeetingMode();
            Console.WriteLine(gsmControler.ToString());

            gsmControler.activateFlightMode();
            Console.WriteLine(gsmControler.ToString());

            gsmControler.activateStandByMode();
            Console.WriteLine(gsmControler.ToString());
        }
    }
}
