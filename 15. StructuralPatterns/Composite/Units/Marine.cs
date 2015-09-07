using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Units
{
    class Marine : Unit
    {
        private const int MarineLifePoints = 100;

        public Marine(string name)
            :base(name, MarineLifePoints)
        {
        }

        public override string GetInfo()
        {
            var info = new StringBuilder();

            info.AppendLine("Marine:");
            info.AppendLine("Name: " + base.Name);
            info.AppendLine("Life points: " + base.LifePoints);

            return info.ToString();
        }
    }
}
