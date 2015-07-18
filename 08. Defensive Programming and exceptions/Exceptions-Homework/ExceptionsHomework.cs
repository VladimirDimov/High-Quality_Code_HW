namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ExceptionsHomework
    {
        public static void Main()
        {
            try
            {
                var substr = StringOperations.Subsequence("Hello!".ToCharArray(), 2, 3);
                Console.WriteLine(substr);

                var subarr = StringOperations.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
                Console.WriteLine(string.Join(" ", subarr));

                var allarr = StringOperations.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
                Console.WriteLine(string.Join(" ", allarr));

                var emptyarr = StringOperations.Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
                Console.WriteLine(string.Join(" ", emptyarr));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine(StringOperations.ExtractEnding("I love C#", 2));
                Console.WriteLine(StringOperations.ExtractEnding("Nakov", 4));
                Console.WriteLine(StringOperations.ExtractEnding("beer", 4));
                Console.WriteLine(StringOperations.ExtractEnding("Hi", 100));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                Console.WriteLine(NumberOperations.CheckPrime(23));
                Console.WriteLine(NumberOperations.CheckPrime(33));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                List<Exam> peterExams = new List<Exam>()
                {
                    new SimpleMathExam(2),
                    new CSharpExam(55),
                    new CSharpExam(100),
                    new SimpleMathExam(1),
                    new CSharpExam(0),
                };
                Student peter = new Student("Peter", "Petrov", peterExams);
                double peterAverageResult = peter.CalcAverageExamResultInPercents();
                Console.WriteLine("Average results = {0:p0}", peterAverageResult);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
