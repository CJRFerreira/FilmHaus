using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FilmHaus.Exceptions
{
    public class InvalidReviewTypeException : Exception
    {
        public InvalidReviewTypeException(string message) : base(message)
        {
        }
    }
}