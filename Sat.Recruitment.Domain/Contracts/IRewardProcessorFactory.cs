using Sat.Recruitment.Domain.Enums;

namespace Sat.Recruitment.Domain.Contracts
{
    public interface IRewardProcessorFactory
    {
        IRewardProcessor GetProcessor(UserType userUserType);
    }
}
