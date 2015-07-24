namespace CompareSortAlgorythms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;

    public delegate void sorter(int[] arr);

    public class PerformanceTester
    {

        public long Test(sorter sorter, int[] arr, int numberOfRepetitions = 1)
        {
            int[] copyOfArr; 
            var timer = new Stopwatch();
            for (int repetition = 0; repetition < numberOfRepetitions; repetition++)
            {
                copyOfArr = (int[])arr.Clone();
                timer.Start();
                sorter(copyOfArr);
                timer.Stop();
            }

            return timer.ElapsedMilliseconds;
        }

        public long Test(sorter sorter, List<int[]> arrays)
        {
            var timer = new Stopwatch();
            int[] copyOfArr;
            foreach (var array in arrays)
            {
                copyOfArr = (int[])array.Clone();
                timer.Start();
                sorter(copyOfArr);
                timer.Stop();
            }

            return timer.ElapsedMilliseconds;
        }

        public long TestForRandom(sorter sorter, int randomArrayLength, int numberOfTests)
        {
            long workingTime = 0;
            var arrayGenerator = new ArrayGenerator();

            for (int i = 0; i < numberOfTests; i++)
            {
                var randomArray = arrayGenerator.GenerateRandomArray(randomArrayLength);
                workingTime += Test(sorter, randomArray);
            }

            return workingTime;
        }
    }
}
