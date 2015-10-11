namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Entry : IComparable<Entry>
    {
        private string name;

        public SortedSet<string> Numbers;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Clear();
            sb.Append('[');
            sb.Append(this.Name);

            bool isBeforeTheFirstPhoneEntry = true;
            foreach (var phone in this.Numbers)
            {
                if (isBeforeTheFirstPhoneEntry)
                {
                    sb.Append(": ");
                    isBeforeTheFirstPhoneEntry = false;
                }
                else
                {
                    sb.Append(", ");
                }

                sb.Append(phone);
            }

            sb.Append(']');

            return sb.ToString();
        }

        public int CompareTo(Entry other)
        {
            return this.name.ToLower().CompareTo(other.name.ToLower());
        }
    }
}
