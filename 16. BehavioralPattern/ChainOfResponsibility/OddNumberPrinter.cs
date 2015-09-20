namespace ChainOfResponsibility
{
    using System;

    public class OddNumberPrinter : NumberPrinter
    {
        public override void Print(int number)
        {
            Console.WriteLine("The number " + number + " is odd.");
        }
    }
}