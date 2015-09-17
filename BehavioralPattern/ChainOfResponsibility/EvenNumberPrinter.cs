namespace ChainOfResponsibility
{
    public class EvenNumberPrinter : NumberPrinter
    {

        public override void Print(int number)
        {
            if (number % 2 != 0 && this.successor != null)
            {
                successor.Print(number);
            }
            else
            {
                System.Console.WriteLine("The number " + number + " is even.");
            }
        }
    }
}