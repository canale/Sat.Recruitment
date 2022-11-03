using FluentAssertions;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.ValueObjects;
using Sat.Recruitment.Test.Helpers.Factories;
using System;
using Xunit;

namespace Sat.Recruitment.Test.Tests.Core.Domain
{
    public class UserTest
    {
        [Theory]
        [InlineData(0, 100, 0)]
        [InlineData(100, 100, 200)]
        [InlineData(100, 200, 300)]
        [InlineData(100, 1, 101)]
        [InlineData(100, 50, 150)]
        [InlineData(100, 0.1, 100.1)]
        [InlineData(10.5, 100, 21)]
        public void AddRewardByPercentage_WithValidPercent_ShouldGetUserWithReward(decimal assets, decimal percentage, decimal result)
        {
            // Arrange

            User SUT = UserFactory.GetValidWithMoney(assets);

            // Action
            User act = SUT.AddRewardByPercentage(percentage);

            // Assertion
            act.Should().NotBeNull();
            act.Money.Value.Should().Be(result);
            act.Name.Value.Should().Be(RecordHelper.Name);
            act.Email.Value.Should().Be(RecordHelper.Email);
            act.Phone.Value.Should().Be(RecordHelper.Phone);
            act.Address.Value.Should().Be(RecordHelper.Address);
            act.UserType.Should().Be(RecordHelper.UserType.ToUserType());
        }

        [Theory]
        [InlineData(0, -100)]
        [InlineData(0, -1)]
        [InlineData(0, -0.1)]
        [InlineData(0, -100000)]
        public void AddRewardByPercentage_WithInvalidPercent_ShouldThrowException(decimal assets, decimal percentage)
        {
            // Arrange
            User SUT = UserFactory.GetValidWithMoney(assets);

            // Action
            Action act = () => SUT.AddRewardByPercentage(percentage);

            // Assertion
            act.Should().ThrowExactly<ArgumentException>();
        }


        [Fact]
        public void IsDuplicated_WithSameUser_ShouldGetDuplicated()
        {
            // Arrange
            User SUT = UserFactory.ValidUser;
            User duplicate = UserFactory.ValidUser;

            // Action
            bool act = SUT.IsDuplicated(duplicate);

            // Assertion
            act.Should().BeTrue();
        }

        [Fact]
        public void IsDuplicated_WithUserWithSameEmail_ShouldGetDuplicated()
        {
            // Arrange
            User SUT = UserFactory.ValidUser;
            User duplicate = UserFactory.GetWith(phone: "1234", name: "Sat", address: "9 de julio 222");

            // Action
            bool act = SUT.IsDuplicated(duplicate);

            // Assertion
            act.Should().BeTrue();
        }

        [Fact]
        public void IsDuplicated_WithUserWithSamePhome_ShouldGetDuplicated()
        {
            // Arrange
            User SUT = UserFactory.ValidUser;
            User duplicate = UserFactory.GetWith(email: "aaa@aaa.com", name: "Sat", address: "9 de julio 222");

            // Action
            bool act = SUT.IsDuplicated(duplicate);

            // Assertion
            act.Should().BeTrue();
        }

        [Fact]
        public void IsDuplicated_WithUserWithSameEmailAndPhome_ShouldGetDuplicated()
        {
            // Arrange
            User SUT = UserFactory.ValidUser;
            User duplicate = UserFactory.GetWith(name: "Sat", address: "9 de julio 222");

            // Action
            bool act = SUT.IsDuplicated(duplicate);

            // Assertion
            act.Should().BeTrue();
        }

        [Fact]
        public void IsDuplicated_WithUserWithSameNameAndAddress_ShouldGetDuplicated()
        {
            // Arrange
            User SUT = UserFactory.ValidUser;
            User duplicate = UserFactory.GetWith(email: "aaa@aaa.com", phone: "1234");

            // Action
            bool act = SUT.IsDuplicated(duplicate);

            // Assertion
            act.Should().BeTrue();
        }

        [Fact]
        public void IsDuplicated_WithUserWithSameName_ShouldGetNotDuplicated()
        {
            // Arrange
            User SUT = UserFactory.ValidUser;
            User duplicate = UserFactory.GetWith(email: "aaa@aaa.com", phone: "1234", address: "9 de julio 222");

            // Action
            bool act = SUT.IsDuplicated(duplicate);

            // Assertion
            act.Should().BeFalse();
        }

        [Fact]
        public void IsDuplicated_WithUserWithDifferentProperties_ShouldGetNotDuplicated()
        {
            // Arrange
            User SUT = UserFactory.ValidUser;
            User duplicate = UserFactory.GetWith(email: "aaa@aaa.com", phone: "1234", name: "Sat", address: "9 de julio 222");

            // Action
            bool act = SUT.IsDuplicated(duplicate);

            // Assertion
            act.Should().BeFalse();
        }
    }
}
