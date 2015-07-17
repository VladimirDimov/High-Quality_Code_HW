namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LocalCourse : Course
    {
        private const int LabMinLength = 3;
        private const int LabMaxLength = 40;

        private string lab;

        public LocalCourse(string name)
            : base(name)
        {
            this.Lab = null;
        }

        public LocalCourse(string courseName, string teacherName)
            : base(courseName, teacherName)
        {
        }

        public LocalCourse(string courseName, string teacherName, IList<string> students)
            : base(courseName, teacherName, students)
        {
        }

        public string Lab
        {
            get
            {
                return this.lab;
            }

            set
            {
                if (value != null && (value.Length < LabMinLength || value.Length > LabMaxLength))
                {
                    throw new InvalidStringLengthException("Lab", LabMinLength, LabMaxLength);
                }

                this.lab = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(base.ToString().TrimEnd(new char[] { '}' }));

            if (this.Lab != null)
            {
                result.Append("; Lab = ");
                result.Append(this.Lab);
            }

            result.Append(" }");

            return result.ToString();
        }
    }
}