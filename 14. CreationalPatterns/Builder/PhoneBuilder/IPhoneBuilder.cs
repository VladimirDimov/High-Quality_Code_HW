namespace Builder.PhoneBuilder
{
    using System;
    using Builder.Enumerations;

    interface IPhoneBuilder
    {
        void SetBattery();
        void SetOperatingSystem();
        void SetScreen();
        Phone GetPhone();
    }
}
