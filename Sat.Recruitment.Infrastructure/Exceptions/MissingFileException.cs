using Sat.Recruitment.Domain.Exceptions;

namespace Sat.Recruitment.Infrastructure.Exceptions
{
    public class MissingFileException : TechnicalException
    {
        public MissingFileException(string message) : base(message)
        {

        }
    }
}
