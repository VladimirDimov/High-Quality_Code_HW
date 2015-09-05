﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Units
{
    public abstract class Tank : Unit
    {
        public Tank(int lifePoints, int armor, int attack, int defense)
            : base(lifePoints, armor, attack, defense)
        {

        }

        public override void SpecialAbility()
        {
            throw new NotImplementedException();
        }
    }
}
