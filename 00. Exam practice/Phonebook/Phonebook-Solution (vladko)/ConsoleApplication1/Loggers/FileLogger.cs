using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Phonebook.Loggers
{
    class FileLogger : ILogger
    {
        private const string Path = "../../../result.txt";

        public FileLogger()
        {
            if (File.Exists(Path))
            {
                File.Delete(Path);
            }
        }

        public void Print(string message)
        {
            using (StreamWriter writer = new StreamWriter(Path, true))
            {
                writer.WriteLine(message);
            }
        }
    }
}
