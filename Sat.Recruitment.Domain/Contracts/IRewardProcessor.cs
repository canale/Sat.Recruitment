using Sat.Recruitment.Domain.ValueObjects;

namespace Sat.Recruitment.Domain.Contracts
{
    public interface IRewardProcessor
    {
        User ProcessReward(User targetUser);
    }
}
