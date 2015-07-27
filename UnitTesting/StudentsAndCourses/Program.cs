using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    class Tester
    {
        static void Main()
        {
            School mySchool = new School("Pesho Peshev");
            Course maths = new Course("Maths");
            maths.AddStudent(new Student("Gosho", "Goshev", 123));
            maths.AddStudent(new Student("Maria", "Petrova", 456));
            maths.AddStudent(new Student("Pencho", "Bonev", 789));
            mySchool.AddCourse(maths);
        }
    }
}
