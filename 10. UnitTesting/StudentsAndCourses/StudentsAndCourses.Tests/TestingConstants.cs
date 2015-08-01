using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses.Tests
{
    public class TestingConstants
    {
        public string[] validSchoolNames = new string[] 
        { 
            "Romen Rolland", 
            "164 GPIE \"Miguel de Cervantes\"", 
            "A.S. Popov School of Electronics",
            "Aprilov National High School",
            "NGDEK",
            "National Gymnasium of Natural Sciences and Mathematics \"Academician Lyubomir Chakalov\"",
        };

        public string[] invalidSchoolNames = new string[] 
        { 
            "Ab", 
            new string('A', 101), 
            ""
        };

        public string[] validStudentFirstNames = new string[]
        {
            "Petar",
            "Gosho",
            "Al"
        };

        public string[] validStudentLastNames = new string[]
        {
            "Petrov",
            "Goshev",
            "Al"
        };

        public string[] invalidStudentNames = new string[]
        {
            "",
            "A",
            "12342341",
            new string('A', 100)
        };

        public int[] validStudentNumbers = new int[]
        {
            10000,
            99999,
            50000
        };

        public int[] invalidStudentNumbers = new int[]
        {
            9999,
            -50000,
            100000
        };

        public string[] validCourseNames = new string[]
        {
            "Math",
            "C# part 2",
            new string('a', 30)
        };

        public string[] invalidCourseNames = new string[]
        {
            "",
            "A",          
            new string('A', 101)
        };

    }
}
