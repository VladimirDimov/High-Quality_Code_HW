namespace Builder.PhoneBuilder
{
    using System;
    using Builder.Enumerations;

    class AndroidPhoneBuilder : IPhoneBuilder
    {
        Phone phoneToBuild = new Phone("Android");

        public void SetBattery()
        {
            phoneToBuild.Batery = BatteryTypes.MAH_1500;
        }

        public void SetOperatingSystem()
        {
            phoneToBuild.OperatingSystem = OperatingSystemTypes.ANDROID;
        }

        public void SetScreen()
        {
            phoneToBuild.Screen = ScreenTypes.TOUCH_RESISTIVE;
        }

        public Phone GetPhone()
        {
            return phoneToBuild;
        }
    }
}
