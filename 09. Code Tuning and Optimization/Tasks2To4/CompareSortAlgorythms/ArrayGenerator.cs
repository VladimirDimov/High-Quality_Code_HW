using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompareSortAlgorythms
{
    class ArrayGenerator
    {
        public int[] GenerateRandomArray(int length)
        {
            var randomArray = new int[length];
            var random = new Random();

            for (int i = 0; i < length; i++)
            {
                randomArray[i] = random.Next(0, length);
            }

            return randomArray;
        }

        public int[] GenerateSortedArray(int length)
        {
            var sortedArray = new int[length];

            for (int i = 0; i < length; i++)
            {
                sortedArray[i] = i;
            }

            return sortedArray;
        }

        public int[] GenerateReversedArray(int length)
        {
            var reversedArray = new int[length];

            for (int i = 0; i < length; i++)
            {
                reversedArray[i] = length - i;
            }

            return reversedArray;
        }

        public IEnumerable<int[]> GenerateListOfRandomArrays(int numberOfArrays, int arraysLength)
        {
            var listOfArrays = new List<int[]>();

            for (int i = 0; i < numberOfArrays; i++)
            {
                listOfArrays.Add(GenerateRandomArray(arraysLength));
            }

            return listOfArrays;
        }
    }
}
