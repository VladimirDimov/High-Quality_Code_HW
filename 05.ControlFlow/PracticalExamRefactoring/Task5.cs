using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PracticalExamRefactoring
{
    class Task5
    {
        internal void Execute()
        {
            var numberS = int.Parse(Console.ReadLine());
            var pattern = GetMostRightNBits(numberS, 5);
            var totalOccurances = 0;

            var numberOfInputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfInputs; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                var currentNumberBits = GetMostRightNBits(currentNumber, 29);
                totalOccurances += CountOccurances(currentNumberBits, pattern);
            }

            Console.WriteLine(totalOccurances);
        }

        private string GetMostRightNBits(int number, int n)
        {
            var bits = new StringBuilder();
            for (int bitIndex = 0; bitIndex < n; bitIndex++)
            {
                bits.Append(1 & (number >> bitIndex));
            }

            var result = new StringBuilder();
            for (int i = bits.Length - 1; i >= 0; i--)
            {
                result.Append(bits[i]);
            }

            return result.ToString();
        }

        private int CountOccurances(string text, string pattern)
        {
            var counter = 0;
            var endOfText = false;
            int left = 0;
            while (!endOfText)
            {
                left = text.IndexOf(pattern, left);
                if (left != -1)
                {
                    counter++;
                    left++;
                }
                else
                {
                    endOfText = true;
                }
            }

            return counter;
        }
    }
}
