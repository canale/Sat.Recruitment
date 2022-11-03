using FluentAssertions;
using Moq;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.ValueObjects;
using Sat.Recruitment.Test.Helpers.Factories;
using System;
using Xunit;

namespace Sat.Recruitment.Test.Tests.Core.Services
{
    public class RewardServiceTest : BaseTest<RewardService>
    {
        private Mock<IRewardProcessorFactory> _rewardProcessorFactory;
        private Mock<IRewardProcessor> _rewardProcessor;

        public RewardServiceTest()
        {
            _rewardProcessorFactory = AddFromInterface<IRewardProcessorFactory>();
            _rewardProcessor = AddFromInterface<IRewardProcessor>();
        }


        [Fact]
        public void AddRewardToUser_WithNullArgument_ShouldThrowException()
        {
            // Arrange
            User nullArg = null;

            var SUT = this.CreateSUT();

            // Action
            Action act = () => SUT.AddRewardToUser(nullArg);

            // Assertion
            act.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void AddRewardToUser_WithValidArgument_ShouldGetAValidUser()
        {
            // Arrange
            User validUser = UserFactory.ValidUser;

            _rewardProcessorFactory
                .Setup(mock => mock.GetProcessor(validUser.UserType))
                .Returns(_rewardProcessor.Object);

            _rewardProcessor
                .Setup(mock => mock.ProcessReward(validUser))
                .Returns(validUser);

            var SUT = this.CreateSUT();

            // Action
            User act = SUT.AddRewardToUser(validUser);

            // Assertion
            act.Should().NotBeNull();
            act.Should().BeEquivalentTo(validUser);
        }
    }
}
