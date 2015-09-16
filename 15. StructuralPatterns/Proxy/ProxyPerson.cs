namespace Proxy
{
    using System;

    class ProxyPerson : IPerson
    {
        private Person person;

        public ProxyPerson(string firstName, string lastName, int age)
        {
            person = new Person();

            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        public string FirstName
        {
            get
            {
                return this.person.FirstName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be null or empty.");
                }

                this.person.FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.person.LastName;
            }

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be null or empty.");
                }

                this.person.LastName = value;
            }
        }

        public int Age
        {
            get
            {
                return this.person.Age;
            }

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("The age must be greater than 0.");
                }

                this.person.Age = value;
            }
        }

        public string FullName
        {
            get
            {
                return this.person.FirstName + " " + this.person.LastName;
            }

            set
            {
                string[] names = value.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (names.Length != 2)
                {
                    throw new ArgumentException("The full name must contain first name and last name.");
                }

                this.person.FirstName = names[0];
                this.person.LastName = names[1];
            }
        }
    }
}
