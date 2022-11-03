using FluentAssertions;
using Sat.Recruitment.Application.Processors;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.ValueObjects;
using Sat.Recruitment.Test.Helpers.Factories;
using Sat.Recruitment.Test.Tests;
using Xunit;

namespace Sat.Recruitment.Test.Core.Appliaction.Processors
{
    public class SuperUserRewardProcessorTest : BaseTest<SuperUserRewardProcessor>
    {

        [Theory]
        [InlineData(100, 100)]
        [InlineData(99, 99)]
        [InlineData(101, 121.2)]
        [InlineData(1000, 1200)]
        [InlineData(0, 0)]
        [InlineData(100.01, 120.012)]
        [InlineData(-1,-1)]
        public void ProcessReward_WithVlaidArguments_ShouldGetUserWithAppliedReward(decimal money, decimal moneyExpected)
        {
            // Arrange
            User user = UserFactory.GetWith(userType: UserType.SuperUser, money:money);

            var SUT = this.CreateSUT();

            // Action
            User act = SUT.ProcessReward(user);

            // Assertion
            act.Should().NotBeNull();
            act.Money.Value.Should().Be(moneyExpected);
        }

    }
}
