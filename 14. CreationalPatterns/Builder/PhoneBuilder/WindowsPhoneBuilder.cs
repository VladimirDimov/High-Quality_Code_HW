namespace Builder.PhoneBuilder
{
    using Builder.Enumerations;

    class WindowsPhoneBuilder : IPhoneBuilder
    {
        Phone phoneToBuild = new Phone("Windows Phone");

        public void SetBattery()
        {
            phoneToBuild.Batery = BatteryTypes.MAH_2000;
        }

        public void SetOperatingSystem()
        {
            phoneToBuild.OperatingSystem = OperatingSystemTypes.WINDOWS_PHONE;
        }

        public void SetScreen()
        {
            phoneToBuild.Screen = ScreenTypes.TOUCH_CAPACITIVE;
        }

        public Phone GetPhone()
        {
            return phoneToBuild;
        }
    }
}
