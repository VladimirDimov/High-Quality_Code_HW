namespace Assertions
{
    using System;
    using System.Diagnostics;

    public static class Search<T> where T : IComparable<T>
    {
        public static int BinarySearch(T[] arr, T value) 
        {
            return BinarySearch(arr, value, 0, arr.Length - 1);
        }

        private static int BinarySearch(T[] arr, T value, int startIndex, int endIndex)
        {
            Debug.Assert(value != null, "Searched value cannot be null.");
            Debug.Assert(arr.Length > 0, "Input array length must be greater than 0");
            Debug.Assert(
                startIndex >= 0 && startIndex <= arr.Length - 1,
                "Invaild start index");
            Debug.Assert(
                endIndex >= 0 && endIndex <= arr.Length - 1,
                "Invalid end index");

            while (startIndex <= endIndex)
            {
                int midIndex = (startIndex + endIndex) / 2;
                if (arr[midIndex].Equals(value))
                {
                    return midIndex;
                }

                if (arr[midIndex].CompareTo(value) < 0)
                {
                    // Search on the right half
                    startIndex = midIndex + 1;
                }
                else
                {
                    // Search on the right half
                    endIndex = midIndex - 1;
                }
            }

            // Searched value not found
            return -1;
        }
    }
}
