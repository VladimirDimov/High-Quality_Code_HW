namespace Composite.Units
{
    using System;

    public abstract class Unit : IUnit
    {
        public Unit(string name, int lifePoints)
        {
            this.Name = name;
            this.LifePoints = lifePoints;
        }
        public string Name
        {
            get;
            set;
        }

        public int LifePoints
        {
            get;
            set;
        }

        public abstract string GetInfo();
    }
}
