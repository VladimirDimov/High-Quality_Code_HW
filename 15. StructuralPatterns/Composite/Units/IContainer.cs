namespace Composite.Units
{
    using System.Collections.Generic;

    interface IContainer
    {
        ICollection<IUnit> Units { get; }
        void AddUnit(IUnit unit);
        void RemoveUnit(IUnit unit);
    }
}
