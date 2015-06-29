namespace RefactoringCode
{
    using System;

    public class Tester
    {
        public static void Main()
        {
            Random randomAge = new Random();
            Person randomPerson = PeopleGenerator.GeneratePersonByAgeNumber(randomAge.Next(1, 35));
            Console.WriteLine(randomPerson);
        }
    }
}