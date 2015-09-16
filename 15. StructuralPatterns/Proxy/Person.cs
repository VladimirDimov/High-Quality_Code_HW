namespace Proxy
{
    class Person : IPerson
    {
        public Person()
        {
        }

        public string FirstName
        {
            get;
            set;
        }

        public string LastName
        {
            get;
            set;
        }

        public int Age
        {
            get;
            set;
        }
    }
}
