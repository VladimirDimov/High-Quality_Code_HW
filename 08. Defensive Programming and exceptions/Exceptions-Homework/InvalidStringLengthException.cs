namespace ExceptionsHomework
{
    using System;

    public class InvalidStringLengthException : Exception
    {
        public InvalidStringLengthException(string variableName, int minLength, int maxLength)
            : base(string.Format("{0} must be between {1} and {2} characters", variableName, minLength, maxLength))
        {
        }
    }
}