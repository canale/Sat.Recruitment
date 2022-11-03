using FluentAssertions;
using Moq;
using Sat.Recruitment.Application.Services;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Dtos;
using Sat.Recruitment.Domain.ValueObjects;
using Sat.Recruitment.Test.Helpers.Factories;
using System;
using System.Linq;
using Xunit;

namespace Sat.Recruitment.Test.Tests.Core.Services
{
    public class UserApplicationServiceTest : BaseTest<UserApplicationService>
    {
        private Mock<IUserRepository> _userRepository;
        private Mock<IRewardService> _rewardService;

        public UserApplicationServiceTest()
        {
            _userRepository = AddFromInterface<IUserRepository>();
            _rewardService = AddFromInterface<IRewardService>();
        }


        [Fact]
        public void CreateUser_WithNullArgument_ShouldThrowException()
        {
            // Arrange
            UserCreationDto nullArg = null;

            var SUT = this.CreateSUT();

            // Action
            Action act = () => SUT.CreateUser(nullArg);

            // Assertion
            act.Should().Throw<ArgumentNullException>();
            _rewardService.Verify(mock => mock.AddRewardToUser(It.IsAny<User>()), Times.Never());
            _userRepository.Verify(mock => mock.AddsUser(It.IsAny<User>()), Times.Never());
        }


        [Fact]
        public void CreateUser_WithDuplicatedArgument_ShouldThrowException()
        {
            // Arrange
            UserCreationDto dto = UserFactory.ValidUserCreationDto;

            _userRepository
                .Setup(mock => mock.GetAll())
                .Returns(new User[] { UserFactory.ValidUser });

            var SUT = this.CreateSUT();

            // Action
            Result<UserCreationDto> act = SUT.CreateUser(dto);

            // Assertion
            act.Should().NotBeNull();
            act.IsSuccess.Should().BeFalse();
            act.Errors.Should().NotBeNull();
            act.Errors.Should().HaveCount(1);
            act.Errors.First().Message.Should().Contain("duplicated");
            act.Errors.First().TargetType.Should().Be(typeof(User));

            _rewardService.Verify(mock => mock.AddRewardToUser(It.IsAny<User>()), Times.Never());
            _userRepository.Verify(mock => mock.AddsUser(It.IsAny<User>()), Times.Never());
        }

        [Fact]
        public void CreateUser_WithValidArgument_ShouldGetSucceedResult()
        {
            // Arrange
            UserCreationDto dto = UserFactory.ValidUserCreationDto;

            _userRepository
                .Setup(mock => mock.GetAll())
                .Returns(Array.Empty<User>());

            _rewardService
                .Setup(mock => mock.AddRewardToUser(It.IsAny<User>()))
                .Returns(UserFactory.ValidUser);

            var SUT = this.CreateSUT();

            // Action
            Result<UserCreationDto> act = SUT.CreateUser(dto);

            // Assertion
            act.Should().NotBeNull();
            act.IsSuccess.Should().BeTrue();
            act.Errors.Should().NotBeNull();
            act.Errors.Should().BeNullOrEmpty();

            _rewardService.Verify(mock => mock.AddRewardToUser(It.IsAny<User>()), Times.Once());
            _userRepository.Verify(mock => mock.AddsUser(It.IsAny<User>()), Times.Once());
        }
    }
}
