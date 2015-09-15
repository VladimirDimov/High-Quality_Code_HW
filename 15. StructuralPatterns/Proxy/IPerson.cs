using System;
namespace Proxy
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    interface IPerson
    {
        string FirstName { get; }
        string LastName { get; }
        int Age { get; }
    }
}
