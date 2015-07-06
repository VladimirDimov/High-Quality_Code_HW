namespace ClassChef
{
    using System;

    public class Chef
    {
        public void Cook()
        {
            // Vegetables must be first peeled before being cut
            Potato potato = GetPotato();
            Peel(potato);
            Cut(potato);

            Carrot carrot = GetCarrot();
            Peel(carrot);
            Cut(carrot);

            Bowl bowl;
            bowl = GetBowl();
            bowl.Add(potato);
            bowl.Add(carrot);
        }

        private static void Peel(IVegitable carrot)
        {
            throw new NotImplementedException();
        }

        private static Potato GetPotato()
        {
            throw new NotImplementedException();
        }

        private static Bowl GetBowl()
        {
            throw new NotImplementedException();
        }

        private static Carrot GetCarrot()
        {
            throw new NotImplementedException();
        }

        private static void Cut(IVegitable potato)
        {
            throw new NotImplementedException();
        }
    }
}
