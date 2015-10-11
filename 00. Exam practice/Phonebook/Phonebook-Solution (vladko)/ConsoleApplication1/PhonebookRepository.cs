namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Phonebook.Loggers;

    public class PhonebookRepository : IPhonebookRepository
    {
        private List<Entry> entries = new List<Entry>();
        private ILogger logger;

        public PhonebookRepository(ILogger logger)
        {
            this.logger = logger;
        }

        public IList<Entry> Entries
        {
            get
            {
                return this.entries;
            }
        }

        public bool AddPhone(string name, IEnumerable<string> newEntryNumbers)
        {
            var old = from e in this.entries
                      where e.Name.ToLowerInvariant() == name.ToLowerInvariant()
                      select e;

            bool entryIsExisting;

            if (old.Count() == 0)
            {
                Entry newEntry = new Entry();

                newEntry.Name = name;
                newEntry.Numbers = new SortedSet<string>();

                foreach (var number in newEntryNumbers)
                {
                    newEntry.Numbers.Add(number);
                }

                this.entries.Add(newEntry);

                entryIsExisting = false;
            }
            else if (old.Count() == 1)
            {
                Entry existingEntry = old.First();
                foreach (var num in newEntryNumbers)
                {
                    existingEntry.Numbers.Add(num);
                }

                entryIsExisting = true;
            }
            else
            {
                logger.Print("Duplicated name in the phonebook found: " + name);

                return true;
            }

            return entryIsExisting;
        }

        public int ChangePhone(string oldEntry, string newEntry)
        {
            var list =
                from e in this.entries
                where e.Numbers.Contains(oldEntry)
                select e;

            int numberOfEntryNumbers = 0;
            foreach (var entry in list)
            {
                entry.Numbers.Remove(oldEntry);
                entry.Numbers.Add(newEntry);
                numberOfEntryNumbers++;
            }

            return numberOfEntryNumbers;
        }

        public Entry[] ListEntries(int start, int num)
        {
            if (start < 0 || start + num > this.entries.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid start index or count.");
            }

            this.entries.Sort();
            Entry[] outputEntries = new Entry[num];

            for (int i = start; i <= start + num - 1; i++)
            {
                Entry entry = this.entries[i];
                outputEntries[i - start] = entry;
            }

            return outputEntries;
        }
    }

}
