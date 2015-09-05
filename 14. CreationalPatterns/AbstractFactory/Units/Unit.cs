using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FactoryMethod.Units
{
    public abstract class Unit:IUnit
    {
        public Unit(int lifePoints, int armor, int attack, int defense)
        {
            this.LifePoints = lifePoints;
            this.Armor = armor;
            this.Attack = attack;
            this.Defense = defense;
        }
        public int LifePoints
        {
            get;
            set;
        }

        public int Armor
        {
            get;
            set;
        }

        public int Attack
        {
            get;
            set;
        }

        public int Defense
        {
            get;
            set;
        }

        public abstract void SpecialAbility(); 
    }
}
