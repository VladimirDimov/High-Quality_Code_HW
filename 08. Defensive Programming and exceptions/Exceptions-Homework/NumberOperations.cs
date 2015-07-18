namespace ExceptionsHomework
{
    using System;

    public static class NumberOperations
    {
        public static string CheckPrime(int number)
        {
            if (IsPrime(number))
            {
                return number + " is prime.";
            }
            else
            {
                return number + " is not prime.";
            }
        }

        private static bool IsPrime(int number)
        {
            if (number == 0)
            {
                return false;
            }

            for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
            {
                if (number % divisor == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}