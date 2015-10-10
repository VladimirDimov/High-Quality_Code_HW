namespace Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Reid : IDrive
    {
        private IList<IDrive> harddrives;

        public Reid()
        {
            this.harddrives = new List<IDrive>();
        }

        public int Capacity
        {
            get
            {
                if (!this.harddrives.Any())
                {
                    return 0;
                }

                return this.harddrives.First().Capacity;
            }
        }

        public void SaveData(int addr, string newData)
        {
            foreach (var hardDrive in this.harddrives)
            {
                hardDrive.SaveData(addr, newData);
            }
        }

        public string LoadData(int address)
        {
            if (!this.harddrives.Any())
            {
                throw new OutOfMemoryException("No hard drive in the RAID array!");
            }

            return this.harddrives.First().LoadData(address);
        }

        public void AddDrive(IDrive drive)
        {
            this.harddrives.Add(drive);
        }
    }
}
