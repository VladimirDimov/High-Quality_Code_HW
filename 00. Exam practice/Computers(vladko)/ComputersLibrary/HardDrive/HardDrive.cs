using System;
using System.Collections.Generic;
using System.Linq;

namespace Computers
{

    public class HardDrive : IDrive
    {
        int capacity;
        Dictionary<int, string> data;

        internal HardDrive(int capacity)
        {
            this.capacity = capacity;

            this.data = new Dictionary<int, string>(capacity);
        }


        internal HardDrive(int capacity, bool isInRaid, int hardDrivesInRaid, List<HardDrive> hardDrives)
        {
            this.capacity = capacity;

            this.data = new Dictionary<int, string>(capacity);
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
        }

        public void SaveData(int address, string newData)
        {
            this.data[address] = newData;
        }

        public string LoadData(int address)
        {
            return this.data[address];
        }
    }
}
