namespace Computers
{
    public class Battery
    {
        public Battery()
        {
            this.Percentage = 50;
        }

        public int Percentage { get; set; }

        public void Charge(int p)
        {
            this.Percentage += p;

            if (this.Percentage > 100)
            {
                this.Percentage = 100;
            }
            else if (this.Percentage < 0)
            {
                this.Percentage = 0;
            }
        }

    }
}
