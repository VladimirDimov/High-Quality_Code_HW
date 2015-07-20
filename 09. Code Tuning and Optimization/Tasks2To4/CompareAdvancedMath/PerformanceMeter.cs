//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CompareAdvancedMath
//{
//    public enum numericTypes { floatType, doubleType, decimalType };

//    public class PerformanceMeter
//    {
//        private int numberOfCycles;
//        private const float floatNumber = 5;
//        private const double doubleNumber = 5;
//        private const decimal decimalNumber = 5;
//        private double storeResult = 0;


//        public PerformanceMeter(int cycles)
//        {
//            this.NumberOfCycles = cycles;
//        }

//        public int NumberOfCycles
//        {
//            get
//            {
//                return this.numberOfCycles;
//            }
//            private set
//            {
//                if (value <= 0)
//                {
//                    throw new ArgumentException("Number of cycles must be greater than 0.");
//                }

//                this.numberOfCycles = value;
//            }
//        }

//        public string GetReport(numericTypes type)
//        {
//            dynamic number = 0;

//            switch (type)
//            {
//                case numericTypes.floatType:
//                    number = floatNumber;
//                    break;
//                case numericTypes.doubleType:
//                    number = doubleNumber;
//                    break;
//                case numericTypes.decimalType:
//                    number = decimalNumber;
//                    break;
//                default:
//                    break;
//            }

//            var builder = new StringBuilder();
//            builder.Append("Type: " + type + Environment.NewLine);
//            builder.Append("Number of cycles: " + this.numberOfCycles + Environment.NewLine);
//            builder.Append("Square root: " + this.MeasureSquareRoot(number) + Environment.NewLine);
//            builder.Append("Natural logarithm: " + this.MeasureNaturalLogarithm(number) + Environment.NewLine);
//            builder.Append("Sin: " + this.MeasureSinus(number) + Environment.NewLine);

//            return builder.ToString();
//        }

//        private void SquareRoot(dynamic number)
//        {
//             storeResult = Math.Sqrt((double)number);
//        }

//        private void NaturalLogarithm(dynamic number)
//        {
//             storeResult = Math.Log((double)number);
//        }

//        private void Sinus(dynamic number)
//        {
//             storeResult = Math.Sin((double)number);
//        }

//        private long MeasureSquareRoot(dynamic number)
//        {
//            return MeasureTime(SquareRoot(number), number);
//        }

//        private long MeasureNaturalLogarithm(dynamic number)
//        {
//            return MeasureTime(NaturalLogarithm(number), number);
//        }

//        private long MeasureSinus(dynamic number)
//        {
//            return MeasureTime(Sinus(number), number);
//        }

//        private long MeasureTime(Action<dynamic> mathOperation, dynamic number)
//        {
//            var timer = new Stopwatch();
//            timer.Start();
//            for (int i = 0; i < this.numberOfCycles; i++)
//            {
//                mathOperation(number);
//            }
//            timer.Stop();

//            return timer.ElapsedMilliseconds;
//        }
//    }
//}
