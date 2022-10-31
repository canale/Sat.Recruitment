using System;
using System.Collections.Generic;
using Sat.Recruitment.Application.Exceptions;
using Sat.Recruitment.Application.Processors;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Application.Factories
{
    public class RewardProcessorFactory : IRewardProcessorFactory
    {
        private static Dictionary<UserType, Type> _processorMap = new Dictionary<UserType, Type>
        {
            { UserType.Normal , typeof(NormalUserRewardProcessor)},
            { UserType.SuperUser , typeof(SuperUserRewardProcessor)},
            { UserType.Premium , typeof(PremiumUserRewardProcessor)},
        };

        private readonly IServiceProvider _serviceProvider;

        public RewardProcessorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IRewardProcessor GetProcessor(UserType userUserType)
        {
            if (!_processorMap.TryGetValue(userUserType, out Type processorType))
            {
                throw new NotFoundProcessorException($"Could´t find processor by userType {userUserType}");
            }

            IRewardProcessor processor = _serviceProvider.GetService (processorType) as IRewardProcessor
                ??  throw new NotFoundProcessorException($"Could´t find processor by userType {userUserType}");;

            return processor;
        }
    }
}
