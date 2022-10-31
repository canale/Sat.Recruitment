using Sat.Recruitment.Domain.ValueObjects;

namespace Sat.Recruitment.Domain.Contracts
{
    public interface IRewardService
    {
        User AddRewardToUser(User user);
    }
}
