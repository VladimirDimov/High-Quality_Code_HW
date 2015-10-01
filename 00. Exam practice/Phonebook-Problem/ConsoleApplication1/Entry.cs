namespace ConsoleApplication1
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Entry : IComparable<Entry>
    {
        private string name;
        private string name2;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
                this.name2 = value.ToLowerInvariant();
            }
        }

        public SortedSet<string> Strings;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(); sb.Clear(); sb.Append('[');
            sb.Append(this.Name);
            bool flag = true;

            foreach (var phone in this.Strings)
            {
                if (flag)
                {
                    sb.Append(": ");
                    flag = false;
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
            return this.name2.CompareTo(other.name2);
        }
    }
}
