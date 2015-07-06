namespace PracticalExamRefactoring
{
    using System;
    using System.Linq;

    public class Task1
    {
        public void Execute()
        {
            int numberA = int.Parse(Console.ReadLine());
            int numberB = int.Parse(Console.ReadLine());
            int numberC = int.Parse(Console.ReadLine());

            int biggestNumber = GetBiggestNumber(numberA, numberB, numberC);
            Console.WriteLine(biggestNumber);

            int smallestNumber = GetSmallestNumber(numberA, numberB, numberC);
            Console.WriteLine(smallestNumber);

            double arithmeticMeanValue = GetArithmeticMean(numberA, numberB, numberC);
            // Prin arithmeticMeanValue with 3 decimal places
            Console.WriteLine(arithmeticMeanValue.ToString("F3"));
        }

        private int GetBiggestNumber(params int[] numbers)
        {
            int biggestNumber = numbers.Max();

            return biggestNumber;
        }

        private int GetSmallestNumber(params int[] numbers)
        {
            int smallestNumber = numbers.Min();

            return smallestNumber;
        }

        private double GetArithmeticMean(params int[] numbers)
        {
            double arithmeticMeanValue = numbers.Average();

            return arithmeticMeanValue;
        }
    }
}
