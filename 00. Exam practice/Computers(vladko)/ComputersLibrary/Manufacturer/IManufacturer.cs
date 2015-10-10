using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Computers
{
    public interface IManufacturer
    {
        PersonalComputer GetPersonalComputer();

        Laptop GetLaptop();

        Server GetServer();
    }
}
