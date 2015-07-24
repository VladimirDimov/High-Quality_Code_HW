namespace CompareSimpleMaths
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public delegate dynamic MathOperation(dynamic number);

    class PerformanceMeter
    {
        private int intNumber = 1;
        private long longNumber = 1;
        private float floatNumber = 1.5f;
        private double doubleNumber = 1.5;
        private decimal decimalNumber = 1.5m;

        public string GetReportForInt(int numberOfLoops)
        {
            var report = new StringBuilder();

            report.AppendLine("          Report for int          ");
            report.AppendLine("==================================");
            report.AppendLine("Number of loops: " + numberOfLoops);
            report.AppendLine("Add: " + MeasureTime(Add, intNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Subtract: " + MeasureTime(Subtract, intNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Increment: " + MeasureTime(Increment, intNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Multiply: " + MeasureTime(Multiply, intNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Devide: " + MeasureTime(Devide, intNumber, numberOfLoops) + " mlSec");

            return report.ToString();
        }

        public string GetReportForLong(int numberOfLoops)
        {
            var report = new StringBuilder();

            report.AppendLine("          Report for long          ");
            report.AppendLine("==================================");
            report.AppendLine("Number of loops: " + numberOfLoops);
            report.AppendLine("Add: " + MeasureTime(Add, longNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Subtract: " + MeasureTime(Subtract, longNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Increment: " + MeasureTime(Increment, longNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Multiply: " + MeasureTime(Multiply, longNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Devide: " + MeasureTime(Devide, longNumber, numberOfLoops) + " mlSec");

            return report.ToString();
        }

        public string GetReportForFloat(int numberOfLoops)
        {
            var report = new StringBuilder();

            report.AppendLine("          Report for float          ");
            report.AppendLine("==================================");
            report.AppendLine("Number of loops: " + numberOfLoops);
            report.AppendLine("Add: " + MeasureTime(Add, floatNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Subtract: " + MeasureTime(Subtract, floatNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Increment: " + MeasureTime(Increment, floatNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Multiply: " + MeasureTime(Multiply, floatNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Devide: " + MeasureTime(Devide, floatNumber, numberOfLoops) + " mlSec");

            return report.ToString();
        }

        public string GetReportForDouble(int numberOfLoops)
        {
            var report = new StringBuilder();

            report.AppendLine("          Report for double          ");
            report.AppendLine("==================================");
            report.AppendLine("Number of loops: " + numberOfLoops);
            report.AppendLine("Add: " + MeasureTime(Add, doubleNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Subtract: " + MeasureTime(Subtract, doubleNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Increment: " + MeasureTime(Increment, doubleNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Multiply: " + MeasureTime(Multiply, doubleNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Devide: " + MeasureTime(Devide, doubleNumber, numberOfLoops) + " mlSec");

            return report.ToString();
        }

        public string GetReportForDecimal(int numberOfLoops)
        {
            var report = new StringBuilder();

            report.AppendLine("          Report for decimal          ");
            report.AppendLine("==================================");
            report.AppendLine("Number of loops: " + numberOfLoops);
            report.AppendLine("Add: " + MeasureTime(Add, decimalNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Subtract: " + MeasureTime(Subtract, decimalNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Increment: " + MeasureTime(Increment, decimalNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Multiply: " + MeasureTime(Multiply, decimalNumber, numberOfLoops) + " mlSec");
            report.AppendLine("Devide: " + MeasureTime(Devide, decimalNumber, numberOfLoops) + " mlSec");

            return report.ToString();
        }


        private dynamic Add(dynamic number)
        {
            return number + number;
        }

        private dynamic Subtract(dynamic number)
        {
            return number - number;
        }

        private dynamic Increment(dynamic number)
        {
            return number++;
        }

        private dynamic Multiply(dynamic number)
        {
            return number * number;
        }

        private dynamic Devide(dynamic number)
        {
            return number / number;
        }

        private long MeasureTime(MathOperation mathOperation, dynamic operationNumber, int numberOfLoops)
        {
            var watch = new Stopwatch();
            for (int i = 0; i < numberOfLoops; i++)
            {
                watch.Start();
                mathOperation(operationNumber);
                watch.Stop();
            }

            return watch.ElapsedMilliseconds;
        }
    }
}
