namespace InheritanceAndPolymorphism
{
    using System;

    public class InvalidStringLengthException : Exception
    {
        public InvalidStringLengthException(string argumentName, int minLength, int maxLength)
            : base(argumentName + " length must be between " + minLength + " and " + maxLength + " characters.")
        {
        }
    }

    public class NullOrEmptyStringException : Exception
    {
        public NullOrEmptyStringException(string argumentName)
            : base(argumentName + " cannot be null or empty")
        {
        }
    }
}