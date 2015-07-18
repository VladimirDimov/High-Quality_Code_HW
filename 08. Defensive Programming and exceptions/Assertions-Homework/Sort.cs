namespace Assertions
{
    using System;
    using System.Diagnostics;

    public class Sort<T> where T : IComparable<T>
    {
        public static void SelectionSort(T[] arr) 
        {
            for (int index = 0; index < arr.Length - 1; index++)
            {
                int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
                Swap(ref arr[index], ref arr[minElementIndex]);
            }
        }
        
        private static void Swap(ref T x, ref T y)
        {
            Debug.Assert(x != null && y != null, "Swaped values cannot be null");

            T oldX = x;
            x = y;
            y = oldX;
        }
        
        private static int FindMinElementIndex(T[] arr, int startIndex, int endIndex)
        {
            Debug.Assert(arr.Length > 0, "Input array length must be greater than 0");
            Debug.Assert(
                startIndex >= 0 && startIndex <= arr.Length - 1,
                "Invaild start index");
            Debug.Assert(
                endIndex >= 0 && endIndex <= arr.Length - 1,
                "Invalid end index");

            int minElementIndex = startIndex;
            for (int i = startIndex + 1; i <= endIndex; i++)
            {
                if (arr[i].CompareTo(arr[minElementIndex]) < 0)
                {
                    minElementIndex = i;
                }
            }

            return minElementIndex;
        }
    }
}
