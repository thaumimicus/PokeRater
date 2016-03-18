using System;
using System.Runtime.Serialization;

namespace PokeRater.Exceptions
{
    public class WinnerNotValidException : Exception
    {
        public WinnerNotValidException()
            : base()
        {

        }
        public WinnerNotValidException(string message)
            : base(message)
        {

        }
        public WinnerNotValidException(string message, Exception inner)
            : base(message, inner)
        {

        }

        // This constructor is needed for serialization.
        protected WinnerNotValidException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}
