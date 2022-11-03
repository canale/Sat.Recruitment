using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.ValueObjects;

namespace Sat.Recruitment.Application.Processors
{
    public class NormalUserRewardProcessor : IRewardProcessor
    {
        /// <summary>
        /// If new user is normal and has more than USD100
        /// </summary>
        /// <param name="targetUser"></param>
        /// <returns></returns>
        public User ProcessReward(User targetUser)
        {
            User processedUser = targetUser;
            
            if (targetUser.Money > 100)
            {
                processedUser = targetUser.AddRewardByPercentage(12m);
            }
            else if (targetUser.Money <= 100 && targetUser.Money > 10)
            {
                processedUser = targetUser.AddRewardByPercentage(8m);
            }

            return processedUser;
        }
    }
}
