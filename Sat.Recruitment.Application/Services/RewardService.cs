using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Guards;
using Sat.Recruitment.Domain.ValueObjects;

namespace Sat.Recruitment.Application.Services
{
    public class RewardService : IRewardService
    {
        private readonly IRewardProcessorFactory _rewardProcessorFactory;

        public RewardService(IRewardProcessorFactory rewardProcessorFactory)
        {
            _rewardProcessorFactory = rewardProcessorFactory;
        }

        /// <summary>
        /// Allows to process a reward of a User.
        /// </summary>
        /// <param name="user">Target user on which the reward  will be applied. </param>
        /// <returns></returns>
        public User AddRewardToUser(User user)
        {
            Guard.For(user).IsNull();

            IRewardProcessor processor = _rewardProcessorFactory.GetProcessor(user.UserType);
            User processedUser = processor.ProcessReward(user);

            return processedUser;
        }
    }
}
