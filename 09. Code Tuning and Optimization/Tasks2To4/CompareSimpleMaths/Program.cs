namespace CompareSimpleMaths
{
    using System;

    class Program
    {
        static void Main()
        {
            var meter = new PerformanceMeter(10000);
            Console.WriteLine(meter.GetReport(numberTypes.typeInt));
            Console.WriteLine(meter.GetReport(numberTypes.typeLong));
            Console.WriteLine(meter.GetReport(numberTypes.typeFloat));
            Console.WriteLine(meter.GetReport(numberTypes.typeDouble));
            Console.WriteLine(meter.GetReport(numberTypes.typeDecimal));
        }
    }
}
