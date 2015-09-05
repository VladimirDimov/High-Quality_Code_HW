namespace Animals
{
    public class Cat : Animal
    {
        internal Cat(string name)
            :base(name)
        {
        }

        public override string Say()
        {
            return "Meau, my name is " + base.Name;
        }
    }
}
