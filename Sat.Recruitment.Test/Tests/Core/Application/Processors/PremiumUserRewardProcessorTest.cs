using FluentAssertions;
using Sat.Recruitment.Application.Processors;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.ValueObjects;
using Sat.Recruitment.Test.Helpers.Factories;
using Sat.Recruitment.Test.Tests;
using Xunit;

namespace Sat.Recruitment.Test.Core.Appliaction.Processors
{
    public class PremiumUserRewardProcessorTest : BaseTest<PremiumUserRewardProcessor>
    {

        [Theory]
        [InlineData(99, 99)]
        [InlineData(101, 303)]
        [InlineData(1000, 3000)]
        [InlineData(0, 0)]
        [InlineData(100.01, 300.03)]
        [InlineData(-1, -1)]
        public void ProcessReward_WithVlaidArguments_ShouldGetUserWithAppliedReward(decimal money, decimal moneyExpected)
        {
            // Arrange
            User user = UserFactory.GetWith(userType: UserType.Premium, money:money);

            var SUT = this.CreateSUT();

            // Action
            User act = SUT.ProcessReward(user);

            // Assertion
            act.Should().NotBeNull();
            act.Money.Value.Should().Be(moneyExpected);
        }

    }
}
