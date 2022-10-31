using Sat.Recruitment.Domain.Exceptions;

namespace Sat.Recruitment.Infrastructure.Exceptions
{
    public class NotFoundConstructionException : TechnicalException
    {
        public NotFoundConstructionException(string message) : base(message)
        {

        }
    }
}
