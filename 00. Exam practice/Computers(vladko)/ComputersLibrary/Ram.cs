namespace Computers
{
    public class Ram
    {
        int value;

        public Ram(int a)
        {
            Amount = a;
        }

        int Amount { get; set; }
        
        public void SaveValue(int newValue)
        {
            value = newValue;
        }
        
        public int LoadValue()
        {
            return value;
        }
    }
}