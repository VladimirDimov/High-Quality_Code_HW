namespace ChainOfResponsibility
{
    /// <summary>
    /// The 'Handler' abstract class
    /// </summary>
    public abstract class NumberPrinter
    {
        protected NumberPrinter successor;

        public void SetSuccessor(NumberPrinter successor)
        {
            this.successor = successor;
        }

        public abstract void Print(int number);
    }
}