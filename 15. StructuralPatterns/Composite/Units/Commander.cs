namespace Composite.Units
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Commander : Unit, IContainer
    {
        private const int CommanderLifePoints = 300;
        private List<IUnit> units;

        public Commander(string name)
            : base(name, CommanderLifePoints)
        {
            this.units = new List<IUnit>();
        }

        public ICollection<IUnit> Units
        {
            get
            {
                return this.units;
            }
        }

        public void AddUnit(IUnit unit)
        {
            this.Units.Add(unit);
        }

        public void RemoveUnit(IUnit unit)
        {
            this.Units.Remove(unit);
        }

        public override string GetInfo()
        {
            var info = new StringBuilder();

            info.AppendLine("Commander:");
            info.AppendLine("Name: " + base.Name);
            info.AppendLine("Life points: " + base.LifePoints);
            info.AppendLine("----------------------");

            foreach (var unit in this.Units)
            {
                info.AppendLine("Contains");
                info.Append(unit.GetInfo());
            }

            return info.ToString().Trim();
        }
    }
}
