namespace RefactoringCode
{
    using System;

    public class BooleanPrinter
    {
        public void PrintBool(bool boolean)
        {
            string boolAsString = boolean.ToString();
            Console.WriteLine(boolAsString);
        }
    }
}
