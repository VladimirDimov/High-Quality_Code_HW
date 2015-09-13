using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Units
{
    public class SuperTankCreator : UnitFactoryMethod
    {
        public override Unit CreateUnit()
        {
            return new SuperTank(300, 300, 300, 300);
        }
    }
}
