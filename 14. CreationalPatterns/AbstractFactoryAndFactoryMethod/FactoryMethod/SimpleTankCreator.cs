namespace FactoryMethod.Units
{
    public class SimpleTankCreator : UnitFactoryMethod
    {
        public override Unit CreateUnit()
        {
            return new SimpleTank(200, 200, 200, 200);
        }
    }
}
