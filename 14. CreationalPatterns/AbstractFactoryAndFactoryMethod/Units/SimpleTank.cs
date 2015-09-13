using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Units
{
    public class SimpleTank : Tank
    {
        internal SimpleTank(int lifePoints, int armor, int attack, int defense)
            : base(lifePoints, armor, attack, defense)
        {

        }
        public override void SpecialAbility()
        {
            Console.WriteLine("Simple tank does special ability");
        }
    }
}
