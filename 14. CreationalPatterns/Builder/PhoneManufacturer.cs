namespace Builder
{
    using Builder.PhoneBuilder;

    class PhoneManufacturer
    {
        public void Construct(IPhoneBuilder phoneBuilder)
        {
            phoneBuilder.SetBattery();
            phoneBuilder.SetOperatingSystem();
            phoneBuilder.SetScreen();
        }
    }
}
