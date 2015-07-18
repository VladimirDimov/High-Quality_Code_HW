namespace Assertions
{
    using System;
    using System.Diagnostics;

    public class AssertionsHomework
    {
        private static void Main()
        {
            int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
            Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
            Sort<int>.SelectionSort(arr);
            Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

            Sort<int>.SelectionSort(new int[0]); // Test sorting empty array
            Sort<int>.SelectionSort(new int[1]); // Test sorting single element array

            Console.WriteLine(Search<int>.BinarySearch(arr, -1000));
            Console.WriteLine(Search<int>.BinarySearch(arr, 0));
            Console.WriteLine(Search<int>.BinarySearch(arr, 17));
            Console.WriteLine(Search<int>.BinarySearch(arr, 10));
            Console.WriteLine(Search<int>.BinarySearch(arr, 1000));
        }
    }
}