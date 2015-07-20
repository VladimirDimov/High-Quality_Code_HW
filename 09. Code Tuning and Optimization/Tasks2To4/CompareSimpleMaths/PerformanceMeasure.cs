namespace CompareSimpleMaths
{
    using System;
    using System.Diagnostics;
    using System.Text;

    public enum numberTypes { typeInt, typeLong, typeFloat, typeDouble, typeDecimal };

    class PerformanceMeter
    {
        private int numberOfCycles;
        private int intNumber = 1;
        private long longNumber = 1;
        private float floatNumber = 1;
        private double doubleNumber = 1;
        private decimal decimalNumber = 1m;

        dynamic tmp;

        public PerformanceMeter(int numberOfCycles)
        {
            this.NumberOfCycles = numberOfCycles;
        }

        public int NumberOfCycles
        {
            get
            {
                return this.numberOfCycles;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Number of cycles must be greater than 0.");
                }

                this.numberOfCycles = value;
            }
        }

        public string GetReport(numberTypes type)
        {
            dynamic number = 0;

            switch (type)
            {
                case numberTypes.typeInt:
                    number = intNumber;
                    break;
                case numberTypes.typeLong:
                    number = longNumber;
                    break;
                case numberTypes.typeFloat:
                    number = floatNumber;
                    break;
                case numberTypes.typeDouble:
                    number = doubleNumber;
                    break;
                case numberTypes.typeDecimal:
                    number = decimalNumber;
                    break;
            }

            var builder = new StringBuilder();
            builder.Append("Report for " + type + Environment.NewLine);
            builder.Append("Number of cycles: " + this.NumberOfCycles + Environment.NewLine);
            builder.Append("Add: ");
            builder.Append(MeasureAdd(number) + " mlsec");
            builder.Append(Environment.NewLine);

            builder.Append("Substract: ");
            builder.Append(MeasureSubstract(number) + " mlsec");
            builder.Append(Environment.NewLine);

            builder.Append("Increment: ");
            builder.Append(MeasureIncreament(number) + " mlsec");
            builder.Append(Environment.NewLine);

            builder.Append("Multiply: ");
            builder.Append(MeasureMultiply(number) + " mlsec");
            builder.Append(Environment.NewLine);

            builder.Append("Devide: ");
            builder.Append(MeasureDevide(number) + " mlsec");
            builder.Append(Environment.NewLine);

            return builder.ToString();
        }

        private void Add(dynamic number)
        {
            tmp = number + number;
        }

        private void Substract(dynamic number)
        {
            var tmp = number - number;
        }

        private void Increment(dynamic number)
        {
            number++;
        }

        private void Multiply(dynamic number)
        {
            tmp = number * number;
        }

        private void Devide(dynamic number)
        {
            tmp = number / number;
        }

        private long MeasureAdd(dynamic number)
        {
            return MeasureTime(() => Add(number));
        }

        private long MeasureSubstract(dynamic number)
        {
            return MeasureTime(() => Substract(number));
        }

        private long MeasureIncreament(dynamic number)
        {
            return MeasureTime(() => Increment(number));
        }

        private long MeasureMultiply(dynamic number)
        {
            return MeasureTime(() => Multiply(number));
        }

        private long MeasureDevide(dynamic number)
        {
            return MeasureTime(() => Devide(number));
        }

        private long MeasureTime(Action MathOperation)
        {
            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < this.NumberOfCycles; i++)
            {
                MathOperation();
            }
            watch.Stop();

            return watch.ElapsedMilliseconds;
        }
    }
}
