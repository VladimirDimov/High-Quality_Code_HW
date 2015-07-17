namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Course
    {
        private const int CourseNameMinLength = 2;
        private const int CourseNameMaxLength = 40;
        private const int PersonNameMinLength = 2;
        private const int PersonNameMaxLength = 40;

        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string courseName)
        {
            this.Name = courseName;
            this.Students = new List<string>();
        }

        public Course(string courseName, string teacherName)
            : this(courseName)
        {
            this.TeacherName = teacherName;
        }

        public Course(string name, string teacherName, IList<string> students)
            : this(name, teacherName)
        {
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == string.Empty)
                {
                    throw new NullOrEmptyStringException("Course.Name");
                }

                if (value.Length < CourseNameMinLength || value.Length > CourseNameMaxLength)
                {
                    throw new InvalidStringLengthException("Course.Name", CourseNameMinLength, CourseNameMaxLength);
                }

                this.name = value;
            }
        }

        public string TeacherName
        {
            get
            {
                return this.teacherName;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new NullOrEmptyStringException("Course.TeacherName");
                }

                if (value.Length < PersonNameMinLength || value.Length > PersonNameMaxLength)
                {
                    throw new InvalidStringLengthException("Course.TeacherName", PersonNameMinLength, PersonNameMaxLength);
                }

                this.teacherName = value;
            }
        }

        public IList<string> Students
        {
            private get
            {
                return this.students;
            }

            set
            {
                if (value as IList<string> == null)
                {
                    throw new ArgumentException("Students collection must be a valid IList of strings");
                }

                this.students = value;
            }
        }

        public void AddStudent(string student)
        {
            if (student == null || student == string.Empty)
            {
                throw new NullOrEmptyStringException("Course.AddStudent(student)");
            }

            if (student.Length < PersonNameMinLength || student.Length > PersonNameMaxLength)
            {
                throw new InvalidStringLengthException("Course.AddStudent(student)", PersonNameMinLength, PersonNameMaxLength);
            }

            this.Students.Add(student);
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(this.GetType().Name + "{ Name = ");
            result.Append(this.Name);

            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            result.Append(" }");

            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }
            else
            {
                return "{ " + string.Join(", ", this.Students) + " }";
            }
        }
    }
}