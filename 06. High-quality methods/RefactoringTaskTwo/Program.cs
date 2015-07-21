// Description: http://bgcoder.com/Contests/Practice/DownloadResource/948
namespace RefactoringTaskTwo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main()
        {
            var numberOfSequences = int.Parse(Console.ReadLine());
            var result = new List<bool>();
            for (int i = 0; i < numberOfSequences; i++)
            {
                int[] currentSequence = (Console.ReadLine().Split(' ')).Select(x => int.Parse(x)).ToArray();
                var sequenceOfAbsoluteDifferences = GetAbsoluteDifferences(currentSequence);
                result.Add(IsIncreasing(sequenceOfAbsoluteDifferences));
            }

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }

        private static bool IsIncreasing(int[] sequence)
        {
            if (sequence == null || sequence.Length == 0)
            {
                throw new ArgumentException("Sequence cannot be null or empty");
            }

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                var currentNumber = sequence[i];
                var nextNumber = sequence[i + 1];
                if (Math.Abs(currentNumber - nextNumber) > 1)
                {
                    return false;
                }

                if (currentNumber > nextNumber)
                {
                    return false;
                }
            }

            return true;
        }

        private static int[] GetAbsoluteDifferences(int[] sequence)
        {
            if (sequence == null || sequence.Length == 0)
            {
                throw new ArgumentException("Sequence cannot be null or empty");
            }

            var absoluteDifferences = new int[sequence.Length - 1];

            for (int i = 0; i < sequence.Length - 1; i++)
            {
                var currentNumber = sequence[i];
                var nextNumber = sequence[i + 1];

                absoluteDifferences[i] = (int)Math.Abs((long)currentNumber - nextNumber);
            }

            return absoluteDifferences;
        }
    }
}