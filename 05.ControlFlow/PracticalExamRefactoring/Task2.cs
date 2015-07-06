namespace PracticalExamRefactoring
{
    using System;
    using System.Collections.Generic;

    public class Task2
    {
        int secretNumber;
        string inputText;
        enum charType { digit, letter, other };

        public void Execute()
        {
            secretNumber = int.Parse(Console.ReadLine());
            inputText = Console.ReadLine();
            List<double> encodedValues = new List<double>();

            char character;
            int position = 0;
            while ((character = inputText[position]) != '@')
            {
                charType type = GetCharType(character);
                double encodedValue = 0;

                switch (type)
                {
                    case charType.digit:
                        encodedValue = GetDigitEncodedValue(character);
                        break;
                    case charType.letter:
                        encodedValue = GetLetterEncodedValue(character);
                        break;
                    case charType.other:
                        encodedValue = GetOtherCharacterEncodedValue(character);
                        break;
                    default:
                        break;
                }

                bool isEven = position % 2 == 0;
                if (isEven)
                {
                    encodedValue = GetEvenEncodedValue(encodedValue);
                }
                else
                {
                    encodedValue = GetOddEncodedValue(encodedValue);
                }

                encodedValues.Add(encodedValue);
                position++;
            }

            foreach (var value in encodedValues)
            {
                bool isFraction = value % 1 != 0;

                if (isFraction)
                {
                    Console.WriteLine("{0:0.00}", value);
                }
                else
                {
                    Console.WriteLine(value);
                }
            }
        }

        private charType GetCharType(char character)
        {
            if (char.IsLetter(character))
            {
                return charType.letter;
            }
            else if (char.IsDigit(character))
            {
                return charType.digit;
            }
            else
            {
                return charType.other;
            }
        }

        private double GetOddEncodedValue(double number)
        {
            double encodedValue = number * 100;
            return encodedValue;
        }

        private double GetEvenEncodedValue(double number)
        {
            double encodedValue = Math.Round(number / 100, 2);
            return encodedValue;
        }

        private double GetLetterEncodedValue(char character)
        {
            double encodedValue = (int)character * secretNumber + 1000;
            return encodedValue;
        }

        private double GetDigitEncodedValue(char character)
        {
            double encodedValue = char.GetNumericValue(character) + secretNumber + 500;
            return encodedValue;
        }

        private double GetOtherCharacterEncodedValue(char character)
        {
            double encodedValue = (int)character - secretNumber;
            return encodedValue;
        }
    }
}