using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Units
{
    internal class SimpleMarine : Marine
    {
        internal SimpleMarine(int lifePoints, int armor, int attack, int defense)
            : base(lifePoints, armor, attack, defense)
        {

        }
        public override void SpecialAbility()
        {
            Console.WriteLine("Simple marine does special ability");
        }
    }
}
