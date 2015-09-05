namespace FactoryMethod.Units
{
    public class SuperMarineCreator : UnitFactoryMethod
    {
        public override Unit CreateUnit()
        {
            return new SuperMarine(150, 150, 150, 150);
        }
    }
}
