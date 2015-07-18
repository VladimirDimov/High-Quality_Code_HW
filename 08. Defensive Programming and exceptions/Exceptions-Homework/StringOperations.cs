namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class StringOperations
    {
        public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
        {
            if (arr == null)
            {
                throw new ArgumentNullException("Subsequence input collection cannot be null.");
            }

            if (startIndex < 0)
            {
                throw new ArgumentException("Start index cannot be negative");
            }

            if (count <= 0)
            {
                throw new ArgumentException("Subsequence length must be greater than 0.");
            }

            if (startIndex + count > arr.Length)
            {
                throw new ArgumentOutOfRangeException("Start index + subsequence length cannot be greater than input array length");
            }

            List<T> result = new List<T>();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                result.Add(arr[i]);
            }

            return result.ToArray();
        }

        public static string ExtractEnding(string str, int count)
        {
            if (count > str.Length)
            {
                throw new ArgumentException("Ending substring length cannot be greater than the input string length");
            }

            StringBuilder result = new StringBuilder();
            for (int i = str.Length - count; i < str.Length; i++)
            {
                result.Append(str[i]);
            }

            return result.ToString();
        }
    }
}
