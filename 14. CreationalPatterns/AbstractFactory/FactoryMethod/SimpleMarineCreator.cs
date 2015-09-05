using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Units
{
    public class SimpleMarineCreator : UnitFactoryMethod
    {
        public override Unit CreateUnit()
        {
            return new SimpleMarine(100, 100, 100, 100);
        }
    }
}
