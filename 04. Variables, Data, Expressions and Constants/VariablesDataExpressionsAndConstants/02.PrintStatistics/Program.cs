namespace _02.PrintStatistics
{
    using System;

    public class Program
    {
        private static void Main()
        {
            PrintStatistics(new double[] { 1, 2, 3, 4, 5, 6 }, 3);
        }

        private static void PrintStatistics(double[] arr, int numberOfElements)
        {
            double max = double.MinValue;

            for (int i = 0; i < numberOfElements; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }

            PrintMax(max);

            double min = double.MaxValue;

            for (int i = 0; i < numberOfElements; i++)
            {
                if (arr[i] < min)
                {
                    min = arr[i];
                }
            }

            PrintMin(min);

            double sum = 0;

            for (int i = 0; i < numberOfElements; i++)
            {
                sum += arr[i];
            }

            double average = sum / numberOfElements;

            PrintAvg(average);
        }

        private static void PrintAvg(double p)
        {
            Console.WriteLine("Average value = " + p);
        }

        private static void PrintMin(double min)
        {
            Console.WriteLine("Minimal value = " + min);
        }

        private static void PrintMax(double max)
        {
            Console.WriteLine("Maximal value = " + max);
        }
    }
}
