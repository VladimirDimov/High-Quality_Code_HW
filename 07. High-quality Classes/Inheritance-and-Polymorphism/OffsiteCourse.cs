namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class OffsiteCourse : Course
    {
        private const int TownMinLength = 3;
        private const int TownMaxLength = 40;

        private string town;

        public OffsiteCourse(string courseName)
            : base(courseName)
        {
            this.Town = null;
        }

        public OffsiteCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
        }

        public OffsiteCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
        }

        public string Town
        {
            get
            {
                return this.town;
            }

            set
            {
                if (value != null && (value.Length < TownMinLength || value.Length < TownMaxLength))
                {
                    throw new InvalidStringLengthException("Town name", 3, 40);
                }

                this.town = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString().TrimEnd(new char[] { '}' }));

            if (this.Town != null)
            {
                result.Append("; Town = ");
                result.Append(this.Town);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}