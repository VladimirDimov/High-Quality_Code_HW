namespace Animals
{
    public class Cow : Animal
    {
        internal Cow(string name)
            : base(name)
        {

        }

        public override string Say()
        {
            return "Muuu, my name is " + base.Name;
        }
    }
}
