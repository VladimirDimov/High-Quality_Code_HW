namespace LoopRefactoring
{
    using System;

    public class Program
    {
        private static void Main()
        {
            int numberOfElements = 100;
            int[] array = new int[numberOfElements];
            int expectedValue = 500;
            bool valueFound = false;

            for (int index = 0; index < numberOfElements; index++)
            {
                if (index % 10 == 0 && array[index] == expectedValue)
                {
                    valueFound = true;
                    break;
                }

                Console.WriteLine(array[index]);
            }

            // More code here
            if (valueFound)
            {
                Console.WriteLine("Value Found");
            }
        }
    }
}
