namespace Animals
{
    public class Dog : Animal
    {
        internal Dog(string name)
            :base(name)
        {
        }

        public override string Say()
        {
            return "Bau, my name is " + base.Name;
        }
    }
}
