using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedMath
{
    class Program
    {
        static void Main()
        {
            var meter = new PerformanceMeter();
            Console.WriteLine(meter.GetReportForSin(100000));
            Console.WriteLine(meter.GetReportForSqrt(100000));
            Console.WriteLine(meter.GetReportForNaturalLog(100000));
        }
    }
}
