// Description: http://bgcoder.com/Contests/Practice/Index/223#1
namespace RefactoringTaskOne
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Program
    {
        private static void Main()
        {
            var result = new List<string>();
            string[] input = Console.ReadLine().Split(' ');

            foreach (var word in input)
            {
                var wordDeciamlValue = ClaculateWordValue(word);
                var intputToDecimals = Get26BaseDigits(wordDeciamlValue);
                var convertedWord = new StringBuilder();

                foreach (var number in intputToDecimals)
                {
                    convertedWord.Append(NumberToChar(number));
                }

                result.Add(convertedWord.ToString());
            }

            Console.WriteLine(string.Join(" ", result));
        }

        private static int ClaculateWordValue(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentException("Words CannotUnloadAppDomainException be null or empty");
            }

            int length = word.Length;
            int decimalValue = 0;
            for (int position = 0; position < length; position++)
            {
                char currentLetter = word[length - position - 1];
                decimalValue += (currentLetter - 'a') * (int)Math.Pow(21, position);
            }

            return decimalValue;
        }

        private static IEnumerable<int> Get26BaseDigits(int inputValue)
        {
            if (inputValue <= 0)
            {
                throw new ArgumentException("Converted number must be greater than 0.");
            }

            var base26NumberValues = new Stack<int>();
            while (inputValue != 0)
            {
                base26NumberValues.Push(inputValue % 26);
                inputValue /= 26;
            }

            return base26NumberValues.ToArray();
        }

        private static char NumberToChar(int number)
        {
            if (number < 0 || 25 < number)
            {
                throw new ArgumentException("Number must be between 0 and 25.");
            }

            return (char)('a' + number);
        }
    }
}
