using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsAndCourses
{
    public class Course
    {
        private const int CourseNameMinLength = 2;
        private const int CourseNameMaxLength = 100;

        private List<Student> students = new List<Student>();
        private HashSet<int> uniqueStudentNumbers = new HashSet<int>();
        private string name;

        public Course(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Courrse name cannot be null or empty");
                }

                if (value.Length < CourseNameMinLength || CourseNameMaxLength < value.Length)
                {
                    throw new ArgumentException("Course name must have between " + CourseNameMinLength + " and " + CourseNameMaxLength + " characters");
                }

                this.name = value;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.uniqueStudentNumbers.Contains(student.Number))
            {
                throw new ArgumentException("A student with number " + student.Number + " is already in the list");
            }
            this.students.Add(student);
            this.uniqueStudentNumbers.Add(student.Number);
        }

        public void RemoveStudentByNumber(int number)
        {
            var index = this.students.FindIndex(student => student.Number == number);

            if (index == -1)
            {
                throw new ArgumentException("Student with number " + number + " is not listed in the course.");
            }

            this.students.RemoveAt(index);
        }

        public List<Student> GetStudents()
        {
            return this.students;
        }
    }
}
