namespace PracticalExamRefactoring
{
    using System;

    class Program
    {
        static void Main()
        {
            Console.Write("Enter the number of the task: ");
            var taskNumber = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter input text:");

            switch (taskNumber)
            {
                case 1:
                    Task1 firstTask = new Task1();
                    firstTask.Execute();
                    break;
                case 2:
                    Task2 secondTask = new Task2();
                    secondTask.Execute();
                    break;
                case 3:
                    Task3 thirdTask = new Task3();
                    thirdTask.Execute();
                    break;
                case 4:
                    Task4 fourthTask = new Task4();
                    fourthTask.Execute();
                    break;
                default:
                    break;
            }
        }
    }
}
