using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace Log4NetExample
{
    class Program
    {
        static void Main()
        {
            // The log file is located in "/bin/debug/MyFirstLogger.log"
            XmlConfigurator.Configure();
            ILog log = LogManager.GetLogger(typeof(Program));

            for (int i = 0; i < 10; i++)
            {
                if (i % 2 == 0)
                {
                    log.Info("Even number detected: " + i);
                }
            }
        }
    }
}
