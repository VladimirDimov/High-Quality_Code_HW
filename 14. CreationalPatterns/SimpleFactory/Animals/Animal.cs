namespace Animals
{
    using System;

    public abstract class Animal
    {
        private string name;

        internal Animal(string name)
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
                    throw new ArgumentException("The name cannot be null or empty");
                }

                this.name = value;
            }
        }

        public abstract string Say();
    }
}
