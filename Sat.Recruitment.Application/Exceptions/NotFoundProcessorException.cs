using Sat.Recruitment.Domain.Exceptions;
using System;
using System.Runtime.Serialization;

namespace Sat.Recruitment.Application.Exceptions
{
    public class NotFoundProcessorException : TechnicalException
    {
        public NotFoundProcessorException()
        {
        }

        public NotFoundProcessorException(string message) : base(message)
        {
        }

        public NotFoundProcessorException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public NotFoundProcessorException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
