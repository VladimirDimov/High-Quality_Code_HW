# Composite #

## Описание ##
Прилага се за реализиране на йерархии от сложни обекти, съдържащи други обекти. Позволява сложните обекти и простите(несъставни) обекти да се манипулират по консистентен начин.

## UML диаграма ##

![1](images/composite.gif)

## Пример ##

Имаме следната йерархия от обекти:

![1](images/composite_1.png)

Класът Commander е Composite клас и може да съдържа child класове имплементиращи интерфейса IUnit.

###Код###
Интерфейси:

    public interface IUnit
    {
        string Name { get; set; }
        int LifePoints { get; set; }
        string GetInfo();
    }

	interface IContainer
    {
        ICollection<IUnit> Units { get; }
        void AddUnit(IUnit unit);
        void RemoveUnit(IUnit unit);
    }

Обекти:

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

	class Marine : Unit
    {
        private const int MarineLifePoints = 100;

        public Marine(string name)
            :base(name, MarineLifePoints)
        {
        }

        public override string GetInfo()
        {
            var info = new StringBuilder();

            info.AppendLine("Marine:");
            info.AppendLine("Name: " + base.Name);
            info.AppendLine("Life points: " + base.LifePoints);

            return info.ToString();
        }
    }

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

	class Application
    {
        static void Main()
        {
            Commander commander = new Commander("Mr Pesho");
            commander.AddUnit(new Marine("Gosho"));
            commander.AddUnit(new Marine("Ivan"));
            commander.AddUnit(new Trooper("Toncho"));
            commander.AddUnit(new Trooper("Penko"));

            Console.WriteLine("======================");
            Console.WriteLine(commander.GetInfo());
            Console.WriteLine("======================");
        }
    }