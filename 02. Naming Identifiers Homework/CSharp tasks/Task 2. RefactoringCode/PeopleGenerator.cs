namespace RefactoringCode
{
    using System;

    public class PeopleGenerator
    {
        private static string[] validMaleFirstNames = { "Petar", "Gosho", "Toncho", "pesho", "Kancho", "Ignasio" };
        private static string[] validMaleLastNames = new string[] { "Petrov", "Goshev", "Tonev", "Ivanov", "Bambukov", "Penchov", "Kolev" };
        private static string[] validFemaleFirstNames = new string[] { "Maria", "Tanya", "Stefka", "Penka" };
        private static string[] validFemaleLastNames = new string[] { "Petrova", "Gosheva", "Toneva", "Ivanova" };

        public static Person GeneratePersonByAgeNumber(int age)
        {
            Person newPerson = new Person();
            Random randomNumber = new Random();

            newPerson.Age = age;

            if (age % 2 == 0)
            {
                newPerson.Name = GetRandomArrayElement(validMaleFirstNames) + " " + GetRandomArrayElement(validMaleLastNames);
                newPerson.Sex = Gender.male;
            }
            else
            {
                newPerson.Name = GetRandomArrayElement(validFemaleFirstNames) + " " + GetRandomArrayElement(validFemaleLastNames);
                newPerson.Sex = Gender.female;
            }

            return newPerson;
        }

        private static string GetRandomArrayElement(string[] array)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next();
            return array[randomIndex % (array.Length - 1)];
        }
    }
}