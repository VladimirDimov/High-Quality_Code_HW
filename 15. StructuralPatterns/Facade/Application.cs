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

            gsmControler.АctivateMeetingMode();
            Console.WriteLine(gsmControler.ToString());

            gsmControler.АctivateFlightMode();
            Console.WriteLine(gsmControler.ToString());

            gsmControler.АctivateStandByMode();
            Console.WriteLine(gsmControler.ToString());
        }
    }
}
