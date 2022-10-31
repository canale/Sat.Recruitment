using Sat.Recruitment.Domain.Exceptions;

namespace Sat.Recruitment.Infrastructure.Exceptions
{
    public class MissingDirectoryException : TechnicalException
    {
        public MissingDirectoryException(string message) : base(message)
        {

        }
    }
}
