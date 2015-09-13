namespace FactoryMethod.AbstractFactory
{
    using FactoryMethod.Units;

    internal class SuperUnitFactory : UnitAbstractFactory
    {
        private const int SuperMarineLifePoints = 150;
        private const int SuperMarineArmor = 150;
        private const int SuperMarineAttack = 150;
        private const int SuperMarineDefense = 150;
        private const int SuperTankLifePoints = 300;
        private const int SuperTankArmor = 300;
        private const int SuperTankAttack = 300;
        private const int SuperTankDefense = 300;

        public override Marine CreateMarine()
        {
            return new SuperMarine(SuperMarineLifePoints, SuperMarineArmor, SuperMarineAttack, SuperMarineDefense);
        }

        public override Tank CreateTank()
        {
            return new SuperTank(SuperTankLifePoints, SuperTankArmor, SuperTankAttack, SuperTankDefense);
        }
    }
}
