using System;
using System.Runtime.Serialization;

namespace FilmHaus.Exceptions
{
    [Serializable]
    public class InvalidReviewTypeException : Exception
    {
        public InvalidReviewTypeException()
        {
        }

        public InvalidReviewTypeException(string message) : base(message)
        {
        }

        public InvalidReviewTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidReviewTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}