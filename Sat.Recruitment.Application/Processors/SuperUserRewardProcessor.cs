using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.ValueObjects;

namespace Sat.Recruitment.Application.Processors
{
    public class SuperUserRewardProcessor : IRewardProcessor
    {
        public User ProcessReward(User targetUser)
        {
            User processedUser = targetUser;

            //If new user is normal and has more than USD100
            if (targetUser.Money > 100)
            {
                processedUser = targetUser.AddRewardByPercentage(20m);
            }

            return processedUser;
        }
    }
}
