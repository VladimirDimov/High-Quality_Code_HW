namespace AdvancedMath
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public enum numericTypes { floatType, doubleType, decimalType };

    public class PerformanceMeter
    {
        private const float FloatNumber = 20f;
        private const double DoubleNumber = 20;
        private const decimal DecimalNumber = 20m;

        public string GetReportForSin(int numberOfLoops)
        {
            var report = new StringBuilder();
            report.AppendLine("             Report for Sinus             ");
            report.AppendLine("==========================================");
            report.AppendLine("Float:   " + MeasureSinOfFloat(numberOfLoops) + " mlSec");
            report.AppendLine("Double:  " + MeasureSinOfDouble(numberOfLoops) + " mlSec");
            report.AppendLine("Decimal: " + MeasureSinOfDecimal(numberOfLoops) + " mlSec");
            report.AppendLine("==========================================");

            return report.ToString();
        }

        public string GetReportForSqrt(int numberOfLoops)
        {
            var report = new StringBuilder();
            report.AppendLine("           Report for Square root         ");
            report.AppendLine("==========================================");
            report.AppendLine("Float:   " + MeasureSinOfFloat(numberOfLoops) + " mlSec");
            report.AppendLine("Double:  " + MeasureSinOfDouble(numberOfLoops) + " mlSec");
            report.AppendLine("Decimal: " + MeasureSqrtOfDecimal(numberOfLoops) + " mlSec");
            report.AppendLine("==========================================");

            return report.ToString();
        }

        public string GetReportForNaturalLog(int numberOfLoops)
        {
            var report = new StringBuilder();
            report.AppendLine("        Report for Natural logarithm      ");
            report.AppendLine("==========================================");
            report.AppendLine("Float:   " + MeasureNaturalLogOfFloat(numberOfLoops) + " mlSec");
            report.AppendLine("Double:  " + MeasureSinOfDouble(numberOfLoops) + " mlSec");
            report.AppendLine("Decimal: " + MeasureNaturalLogOfDecimal(numberOfLoops) + " mlSec");
            report.AppendLine("==========================================");

            return report.ToString();
        }

        public long MeasureSinOfFloat(int loops)
        {
            return MeasureTime(Math.Sin, FloatNumber, loops);
        }

        public long MeasureSinOfDouble(int loops)
        {
            return MeasureTime(Math.Sin, DoubleNumber, loops);
        }

        public long MeasureSinOfDecimal(int loops)
        {
            return MeasureTime(Math.Sin, DecimalNumber, loops);
        }

        public long MeasureSqrtOfFloat(int loops)
        {
            return MeasureTime(Math.Sqrt, FloatNumber, loops);
        }

        public long MeasureSqrtOfDouble(int loops)
        {
            return MeasureTime(Math.Sqrt, DoubleNumber, loops);
        }

        public long MeasureSqrtOfDecimal(int loops)
        {
            return MeasureTime(Math.Sqrt, DecimalNumber, loops);
        }

        public long MeasureNaturalLogOfFloat(int loops)
        {
            return MeasureTime(Math.Log, FloatNumber, loops);
        }

        public long MeasureNaturalLogOfDouble(int loops)
        {
            return MeasureTime(Math.Log, DoubleNumber, loops);
        }

        public long MeasureNaturalLogOfDecimal(int loops)
        {
            return MeasureTime(Math.Log, DecimalNumber, loops);
        }

        private long MeasureTime(Func<double, double> mathOperation, dynamic inputNumber, int loops)
        {
            var timer = new Stopwatch();
            for (int i = 0; i < loops; i++)
            {
                timer.Start();
                mathOperation((double)inputNumber);
                timer.Stop();
            }

            return timer.ElapsedMilliseconds;
        }
    }
}
