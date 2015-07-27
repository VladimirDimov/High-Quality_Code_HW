using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentsAndCourses
{
    public class Course
    {
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
                this.name = value;
            }
        }
    
        public void AddStudent(Student student)
        {
            this.students.Add(student);
            this.uniqueStudentNumbers.Add(student.Number);
        }

        public void RemoveStudentByNumber(int number)
        {
            this.students.FindIndex(student => student.Number == number);
        }

        public List<Student> GetStudents()
        {
            return this.students;
        }        
    }
}
