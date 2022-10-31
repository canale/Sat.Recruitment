using Sat.Recruitment.Domain.ValueObjects;

namespace Sat.Recruitment.Domain.Contracts
{
    public interface IRewardApplicationService
    {
        User AddRewardToUser(User user);
    }
}
