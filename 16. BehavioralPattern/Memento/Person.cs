namespace Memento
{
    using System;

    class Person
    {
        private string firstName;
        private string lastName;
        private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
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
                    throw new ArgumentException("First name cannot be null or empty");
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
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty");
                }

                this.lastName = value;
            }
        }

        public string GetInfo()
        {
            return this.FirstName + " " + this.LastName + ", Age: " + this.Age;
        }

        public int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Age must be greater than zero.");
                }

                this.age = value;
            }
        }

        public PersonMemento Save()
        {
            return new PersonMemento(this.FirstName, this.LastName, this.Age);
        }

        public void Load(PersonMemento state)
        {
            this.FirstName = state.FirstName;
            this.LastName = state.LastName;
            this.Age = state.Age;
        }
    }
}
