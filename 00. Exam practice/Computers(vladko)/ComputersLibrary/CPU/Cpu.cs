namespace Computers
{
    using System;

    public abstract class Cpu
    {
        private readonly byte numberOfBits;
        protected readonly IMotherboard motherboard;
        static readonly Random Random = new Random();

        internal Cpu(byte numberOfCores, byte numberOfBits, IMotherboard motherboard)
        {
            this.numberOfBits = numberOfBits;
            this.NumberOfCores = numberOfCores;
            this.motherboard = motherboard;
        }

        byte NumberOfCores { get; set; }

        public abstract void SquareNumber();

        public void rand(int a, int b)
        {
            int randomNumber = Random.Next(a, b);
            this.motherboard.SaveRamValue(randomNumber);
        }
    }
}
