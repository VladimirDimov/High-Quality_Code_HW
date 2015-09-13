namespace FactoryMethod.AbstractFactory
{
    using FactoryMethod.Units;

    public abstract class UnitAbstractFactory
    {
        public abstract Marine CreateMarine();
        public abstract Tank CreateTank();
    }
}
