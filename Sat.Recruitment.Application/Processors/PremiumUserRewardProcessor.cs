using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.ValueObjects;

namespace Sat.Recruitment.Application.Processors
{
    public class PremiumUserRewardProcessor : IRewardProcessor
    {
        public User ProcessReward(User targetUser)
        {
            User processedUser = targetUser;

            if (targetUser.Money > 100)
            {
                processedUser = targetUser.AddRewardByPercentage(200);
            }

            return processedUser;
        }
    }
}
