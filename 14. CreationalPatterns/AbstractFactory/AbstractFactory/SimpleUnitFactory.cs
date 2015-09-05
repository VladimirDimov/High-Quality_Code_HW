namespace FactoryMethod.AbstractFactory
{
    using FactoryMethod.Units;

    public class SimpleUnitFactory : UnitAbstractFactory
    {
        private const int SimpleMarineLifePoints = 100;
        private const int SimpleMarineArmor = 100;
        private const int SimpleMarineAttack = 100;
        private const int SimpleMarineDefense = 100;
        private const int SimpleTankLifePoints = 200;
        private const int SimpleTankArmor = 200;
        private const int SimpleTankAttack = 200;
        private const int SimpleTankDefense = 200;

        public override Marine CreateMarine()
        {
            return new SimpleMarine(SimpleMarineLifePoints, SimpleMarineArmor, SimpleMarineAttack, SimpleMarineDefense);
        }

        public override Tank CreateTank()
        {
            return new SimpleTank(SimpleTankLifePoints, SimpleTankArmor, SimpleTankAttack, SimpleTankDefense);
        }
    }
}
