using Phonebook.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    public interface IPhonebookRepository
    {
        IList<Entry> Entries { get; }

        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        Entry[] ListEntries(int startIndex, int count);
    }

}
