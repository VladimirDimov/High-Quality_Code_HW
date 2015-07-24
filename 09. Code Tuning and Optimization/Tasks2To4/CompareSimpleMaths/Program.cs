namespace CompareSimpleMaths
{
    using System;

    class Program
    {
        static void Main()
        {
            var meter = new PerformanceMeter();
            Console.WriteLine(meter.GetReportForInt(1000));
            Console.WriteLine(meter.GetReportForLong(1000));
            Console.WriteLine(meter.GetReportForFloat(1000));
            Console.WriteLine(meter.GetReportForDouble(1000));
            Console.WriteLine(meter.GetReportForDecimal(1000));
        }
    }
}
