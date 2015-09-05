using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Units
{
    public interface IUnit
    {
        int LifePoints { get; set; }
        int Armor { get; set; }
        int Attack { get; set; }
        int Defense { get; set; }
    }
}
