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
            var meter = new PerformanceMeter(1000000);
            Console.WriteLine(meter.GetReport(numericTypes.floatType));
            Console.WriteLine(meter.GetReport(numericTypes.doubleType));
            Console.WriteLine(meter.GetReport(numericTypes.decimalType));
        }
    }
}
