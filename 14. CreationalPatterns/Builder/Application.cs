namespace Builder
{
    using Builder.PhoneBuilder;
    using System;

    class Application
    {
        static void Main()
        {
            // Building Android phone
            var androidBuilder = new AndroidPhoneBuilder();
            var androidManufacturer = new PhoneManufacturer();
            androidManufacturer.Construct(androidBuilder);

            var androidPhone = androidBuilder.GetPhone();

            Console.WriteLine(androidPhone);
        }
    }
}
