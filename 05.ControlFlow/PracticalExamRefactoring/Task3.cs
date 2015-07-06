namespace PracticalExamRefactoring
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class Task3
    {
        public void Execute()
        {
            var numbers = new List<int>();
            int numberOfCycles = (int)Math.Ceiling((double)numbers.Count);
            var cyclesProducts = new List<BigInteger>();

            int position = 0;
            string input;
            BigInteger totalCycleProduct = 1;
            while ((input = Console.ReadLine()) != "END")
            {
                if (IsEndOfCycle(position))
                {
                    cyclesProducts.Add(totalCycleProduct);
                    totalCycleProduct = 1;
                }

                if (position % 2 != 0)
                {
                    position++;
                    continue;
                }

                int currentNumber = int.Parse(input);
                BigInteger productOfDigits = GetProductOfDigits(currentNumber);
                totalCycleProduct *= productOfDigits;

                position++;
            }

            if (totalCycleProduct != 1)
            {
                cyclesProducts.Add(totalCycleProduct);
            }

            foreach (var product in cyclesProducts)
            {
                Console.WriteLine(product);
            }
        }

        private bool IsEndOfCycle(int position)
        {
            var isEndOfCycle = (position + 1) % 10 == 0;
            return isEndOfCycle;
        }

        private int GetProductOfDigits(int number)
        {
            int product = 1;
            while (number != 0)
            {
                int multiplyer = number % 10;
                if (multiplyer != 0)
                {
                    product *= multiplyer;
                }

                number /= 10;
            }

            return product;
        }
    }
}