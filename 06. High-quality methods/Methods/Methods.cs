namespace Methods
{
    using System;
    using System.Numerics;

    public class Methods
    {
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Sides should be positive.");
            }
            if (a > (b + c) || b > (a + c) || c > (a + b))
            {
                throw new ArgumentException("A triangle side cannot be greater than the sum of the others two.");
            }

            double semiPerimeter = (a + b + c) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
            return area;
        }

        static string NumberToDigit(int number)
        {
            if (number < 0 || 9 < number)
            {
                throw new ArgumentOutOfRangeException("Input number", "Number must be in the range 0 to 9");
            }

            switch (number)
            {
                case 0: return "zero";
                case 1: return "one";
                case 2: return "two";
                case 3: return "three";
                case 4: return "four";
                case 5: return "five";
                case 6: return "six";
                case 7: return "seven";
                case 8: return "eight";
                case 9: return "nine";
                default:
                    return "Invalid digit";
            }
        }

        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("There must be at least one input number.");
            }

            int maxNumber = elements[0];
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxNumber)
                {
                    maxNumber = elements[i];
                }
            }

            return maxNumber;
        }

        static void PrintAsNumber(double number, string format)
        {
            switch (format)
            {
                case "f":
                    Console.WriteLine("{0:f2}", number);
                    break;
                case "%":
                    Console.WriteLine("{0:p0}", number);
                    break;
                case "r":
                    Console.WriteLine("{0,8}", number);
                    break;
                default:
                    throw new ArgumentException("Invalid format value");
            }
        }


        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            checked
            {
                double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
                return distance;
            }
        }

        static bool IsHorizintal(double x1, double y1, double x2, double y2)
        {
            if (x1==x2 && y1==y2)
            {
                throw new ArgumentException("Starting point cannot equal the ending point.");
            }

            bool isHorizontal = (y1 == y2);
            return isHorizontal;
        }

        static bool IsVertical(double x1, double y1, double x2, double y2)
        {
            if (x1 == x2 && y1 == y2)
            {
                throw new ArgumentException("Starting point cannot equal the ending point.");
            }

            bool isVertical = (x1 == x2);
            return isVertical;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(7, 7, 7));

            Console.WriteLine(NumberToDigit(9));

            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 20));

            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");
            PrintAsNumber(50, "%");

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine(CalcDistance(0, 0, double.MaxValue, 2.5));
            Console.WriteLine("Horizontal? " + IsHorizintal(3, -1, 3, 2.5));
            Console.WriteLine("Vertical? " + IsVertical(3, -1, 3, 2.5));

            Student peter = new Student("Peter", "Ivanov", "From Sofia, born at 17.03.1992");

            Student stella = new Student("Stella", "Markova", "From Vidin, gamer, high results, born at 03.11.1993");

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }


}
