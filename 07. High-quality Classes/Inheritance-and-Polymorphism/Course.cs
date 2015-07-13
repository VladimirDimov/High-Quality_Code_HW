namespace InheritanceAndPolymorphism
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private string name;
        private string teacherName;
        private IList<string> students;

        public Course(string name)
        {
            this.Name = name;
        }

        public Course(string name, string teacherName)
            : this(name)
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

                if (value.Length < 2 || value.Length > 20)
                {
                    throw new InvalidStringLengthException("Course.Name", 2, 20);
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

                if (value.Length < 3 || value.Length > 30)
                {
                    throw new InvalidStringLengthException("Course.TeacherName", 3, 30);
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
                if (value == null || value.Count == 0)
                {
                    throw new ArgumentException("Course students cannot be null or empty collection");
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

            if (student.Length < 3 || student.Length > 30)
            {
                throw new InvalidStringLengthException("Course.AddStudent(student)", 3, 30);
            }

            this.Students.Add(student);
        }
    }
}