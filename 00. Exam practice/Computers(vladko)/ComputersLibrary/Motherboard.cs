namespace Computers
{
    using System;

    public class Motherboard : IMotherboard
    {
        private Ram ram;
        private VideoCard videoCard;

        public Motherboard(Ram ram, VideoCard videoCard)
        {
            this.ram = ram;
            this.videoCard = videoCard;
        }

        public int LoadRamValue()
        {
            return this.ram.LoadValue();
        }

        public void SaveRamValue(int value)
        {
            this.ram.SaveValue(value);
        }

        public void DrawOnVideoCard(string message)
        {
            this.videoCard.Draw(message);
        }
    }
}
