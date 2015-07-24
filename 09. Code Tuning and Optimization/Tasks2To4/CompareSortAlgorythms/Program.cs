namespace CompareSortAlgorythms
{
    using System;
    using System.Linq;
    using System.Text;

    class Program
    {
        static void Main()
        {
            Console.WriteLine(GetReportForRandomArrays(100, 1000));
            Console.WriteLine();
            Console.WriteLine(GetReportForReversed(1000, 10000));
            Console.WriteLine();
            Console.WriteLine(GetReportForSortedArray(1000, 10000));
        }

        private static string GetReportForRandomArrays(int numberOfArrays, int arraysLength)
        {
            var arrayGenerator = new ArrayGenerator();
            var collectionOfRandomArrays = arrayGenerator.GenerateListOfRandomArrays(numberOfArrays, arraysLength).ToList();

            var tester = new PerformanceTester();
            var selectionSortMilliseconds = tester.Test(SelectionSort.Sort, collectionOfRandomArrays);
            var quickSortMilliseconds = tester.Test(QuickSort.Sort, collectionOfRandomArrays);
            var insertionSortMilliseconds = tester.Test(InsertionSort.Sort, collectionOfRandomArrays);

            var builder = new StringBuilder();
            builder.AppendLine("======================================");
            builder.AppendLine("       Report for random arrays       ");
            builder.AppendLine("======================================");
            builder.AppendLine("Number of arrays: " + numberOfArrays);
            builder.AppendLine("Arrays length: " + arraysLength);
            builder.AppendLine("Selection sort time elapsed:" + selectionSortMilliseconds + " mlSec");
            builder.AppendLine("Quick sort time elapsed:" + quickSortMilliseconds + " mlSec");
            builder.AppendLine("Insertion sort time elapsed:" + insertionSortMilliseconds + " mlSec");
            builder.AppendLine("======================================");

            return builder.ToString();
        }

        private static string GetReportForReversed(int numberOfRepetitions, int arrayLength)
        {
            var arrayGenerator = new ArrayGenerator();
            var reversedArray = arrayGenerator.GenerateReversedArray(arrayLength);

            var tester = new PerformanceTester();
            var selectionSortMilliseconds = tester.Test(SelectionSort.Sort, reversedArray);
            var quickSortMilliseconds = tester.Test(QuickSort.Sort, reversedArray);
            var insertionSortMilliseconds = tester.Test(InsertionSort.Sort, reversedArray);

            var builder = new StringBuilder();
            builder.AppendLine("======================================");
            builder.AppendLine("       Report for reversed arrays       ");
            builder.AppendLine("======================================");
            builder.AppendLine("Array length: " + arrayLength);
            builder.AppendLine("Number of repetitions: " + numberOfRepetitions);
            builder.AppendLine("Selection sort time elapsed:" + selectionSortMilliseconds + " mlSec");
            builder.AppendLine("Quick sort time elapsed:" + quickSortMilliseconds + " mlSec");
            builder.AppendLine("Insertion sort time elapsed:" + insertionSortMilliseconds + " mlSec");
            builder.AppendLine("======================================");

            return builder.ToString();
        }

        private static string GetReportForSortedArray(int numberOfRepetitions, int arrayLength)
        {
            var arrayGenerator = new ArrayGenerator();
            var sortedArray = arrayGenerator.GenerateSortedArray(arrayLength);

            var tester = new PerformanceTester();
            var selectionSortMilliseconds = tester.Test(SelectionSort.Sort, sortedArray);
            var quickSortMilliseconds = tester.Test(QuickSort.Sort, sortedArray);
            var insertionSortMilliseconds = tester.Test(InsertionSort.Sort, sortedArray);

            var builder = new StringBuilder();
            builder.AppendLine("======================================");
            builder.AppendLine("       Report for sorted arrays       ");
            builder.AppendLine("======================================");
            builder.AppendLine("Array length: " + arrayLength);
            builder.AppendLine("Number of repetitions: " + numberOfRepetitions);
            builder.AppendLine("Selection sort time elapsed:" + selectionSortMilliseconds + " mlSec");
            builder.AppendLine("Quick sort time elapsed:" + quickSortMilliseconds + " mlSec");
            builder.AppendLine("Insertion sort time elapsed:" + insertionSortMilliseconds + " mlSec");
            builder.AppendLine("======================================");

            return builder.ToString();
        }

    }
}
