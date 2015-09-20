namespace Strategy
{
    using System;

    public class BluePrinter : Printer
    {
        public override void Print(string text)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(text);
        }
    }
}
