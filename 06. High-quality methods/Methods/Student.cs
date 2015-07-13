namespace Methods
{
    using System;

    public class Student
    {
        private const int PersonNameMinLength = 2;
        private const int PersonNameMaxLength = 20;

        private string firstName;
        private string lastName;
        private string otherInfo;
        private DateTime dateOfBirth;

        public Student(string firstName, string lastName, string otherInfo)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.OtherInfo = otherInfo;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Person name cannot be null or empty");
                }

                if (value.Length < PersonNameMinLength || value.Length > PersonNameMaxLength)
                {
                    throw new ArgumentException("Person first name must be between " + PersonNameMinLength +
                        " and " + PersonNameMaxLength + "characters");
                }

                this.firstName = value;
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
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Person last name cannot be null or empty");
                }

                if (value.Length < PersonNameMinLength || value.Length > PersonNameMaxLength)
                {
                    throw new ArgumentException("Person last name must be between " + PersonNameMinLength +
                        " and " + PersonNameMaxLength + "characters");
                }

                this.lastName = value;
            }
        }

        public string OtherInfo 
        {
            get
            {
                return this.otherInfo;
            }
            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentException("Person other info cannot be null or empty");
                }

                if (value.Length < 10)
                {
                    throw new ArgumentException("Person other info length must be at least 10 characters.");
                }

                if (!DateTime.TryParse(value.Substring(value.Length - 10), out this.dateOfBirth))
                {
                    throw new ArgumentException("Person other info must end with valid date of birth");
                }

                this.otherInfo = value;
            }
        }

        public DateTime DateOfBirth 
        {
            get
            {
                return this.dateOfBirth;
            }

            private set
            {
                this.dateOfBirth = value;
            }
        }

        public bool IsOlderThan(Student other)
        {
            bool isOlderThan = this.DateOfBirth > other.DateOfBirth;
            return isOlderThan;
        }
    }
}
