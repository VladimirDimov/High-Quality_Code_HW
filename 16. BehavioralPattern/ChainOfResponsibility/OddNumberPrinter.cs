namespace ChainOfResponsibility
{
    using System;

    /// <summary>
    /// The 'ConcreteHandler' class
    /// </summary>
    public class OddNumberPrinter : NumberPrinter
    {
        public override void Print(int number)
        {
            Console.WriteLine("The number " + number + " is odd.");
        }
    }
}