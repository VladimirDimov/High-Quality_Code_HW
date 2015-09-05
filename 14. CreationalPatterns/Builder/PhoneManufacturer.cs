using Builder.PhoneBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
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
