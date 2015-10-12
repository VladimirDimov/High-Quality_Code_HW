namespace CalendarSystem
{
    using System;

    public class Event : IComparable<Event>
    {
        public string Title { get; set; }

        public string Location { get; set; }

        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            string form = "{0:yyyy-MM-ddTH:mm:ss} | {1}";
            if (this.Location != null)
            {
                form += " | {2}";
            }

            string eventAsString = string.Format(form, this.DateTime, this.Title, this.Location);
            return eventAsString;
        }

        public int CompareTo(Event x)
        {
            int result = DateTime.Compare(this.DateTime, x.DateTime);

            if (result == 0)
            {
                result = string.Compare(this.Title, x.Title, StringComparison.Ordinal);
            }

            return result;
        }
    }
}
