namespace Composite.Units
{
    public interface IUnit
    {
        string Name { get; set; }
        int LifePoints { get; set; }
        string GetInfo();
    }
}
