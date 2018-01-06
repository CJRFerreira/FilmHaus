using System;
using System.Runtime.Serialization;

/// <summary>
/// Name: Christian Ferreira
/// Date: September 6th - January 5th
///
/// Statement of Authorship:
/// I, Christian Ferreira (Student #: 000346210), certify that this material is my original work.
/// No other person's work has been used without due acknowledgement.
/// </summary>
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