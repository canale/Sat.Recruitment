using FluentAssertions;
using Sat.Recruitment.Application.Processors;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.ValueObjects;
using Sat.Recruitment.Test.Helpers.Factories;
using Sat.Recruitment.Test.Tests;
using Xunit;

namespace Sat.Recruitment.Test.Core.Appliaction.Processors
{
    public class NormalUserRewardProcessorTest : BaseTest<NormalUserRewardProcessor>
    {
        [Theory]
        [InlineData(100, 108)]
        [InlineData(99, 106.92)]
        [InlineData(101, 113.12)]
        [InlineData(1000, 1120)]
        [InlineData(0, 0)]
        [InlineData(10, 10)]
        [InlineData(9, 9)]
        [InlineData(1, 1)]
        [InlineData(10.01, 10.8108)]
        [InlineData(100.01, 112.0112)]
        [InlineData(-1, -1)]
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
