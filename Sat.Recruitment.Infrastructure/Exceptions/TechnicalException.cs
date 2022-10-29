using System;
using System.Runtime.Serialization;

namespace Sat.Recruitment.Infrastructure.Exceptions
{ 
    public abstract class TechnicalException : Exception
    {
        protected TechnicalException()
        {
        }

        protected TechnicalException(string message) : base(message)
        {
        }

        protected TechnicalException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected TechnicalException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
