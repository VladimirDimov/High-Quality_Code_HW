namespace Computers
{
    using System;

    public class ManufacturerFactory
    {
        public IManufacturer GetManufacturer(string name)
        {
            if (name == "HP")
            {
                return new HpManufacturer();
            }
            else if (name == "Dell")
            {
                return new DellManufacturer();
            }
            else if (name == "Lenovo")
            {
                return new LenovoManufacturer();
            }
            else
            {
                throw new ArgumentException("Invalid manufacturer!");
            }
        }
    }
}
