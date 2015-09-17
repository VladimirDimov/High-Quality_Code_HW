namespace ChainOfResponsibility
{
    using System;

    class Application
    {
        static void Main()
        {
            // Set the chain
            var evenNumberPrinter = new EvenNumberPrinter();
            var oddNumberPrinter = new OddNumberPrinter();
            evenNumberPrinter.SetSuccessor(oddNumberPrinter);


            for (int i = 0; i < 10; i++)
            {
                evenNumberPrinter.Print(i);
            }
        }
    }
}
