using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsAndCourses
{
    public class Student
    {
        private const int NameMinLength = 2;
        private const int NameMaxLength = 30;
        private const int NumberMinValue = 10000;
        private const int NumberMaxValue = 99999;

        private string firstName;
        private int number;
        private string lastName;

        public Student(string firstName, string lastName, int number)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Number = number;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student first name cannot be null or empty.");
                }

                if (value.Length < NameMinLength || NameMaxLength < value.Length)
                {
                    throw new ArgumentException("Invalid first name number of characters");
                }

                this.firstName = value;
            }
        }

        public int Number
        {
            get
            {
                return this.number;
            }
            set
            {
                if (value < NumberMinValue || NumberMaxValue < value)
                {
                    throw new ArgumentException("Student number must be between " + NumberMinValue + " and " + NumberMaxValue);
                }

                this.number = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Student last name cannot be null or empty.");
                }

                if (value.Length < NameMinLength || NameMaxLength < value.Length)
                {
                    throw new ArgumentException("Invalid last name number of characters");
                }

                this.lastName = value;
            }
        }
    }
}
