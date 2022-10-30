using System.Collections.Generic;
using Sat.Recruitment.Domain.ValueObjects;

namespace Sat.Recruitment.Domain.Contracts
{
    public interface IUserRepository
    {
        void AddsUser(User user);

        IList<User> GetAll();
    }
}
