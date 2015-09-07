using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Units
{
    class Trooper : Unit
    {
        private const int TrooperLifePoints = 150;

        public Trooper(string name)
            :base(name, TrooperLifePoints)
        {
        }

        public override string GetInfo()
        {
            var info = new StringBuilder();

            info.AppendLine("Trooper:");
            info.AppendLine("Name: " + base.Name);
            info.AppendLine("Life points: " + base.LifePoints);

            return info.ToString();

        }
    }
}
