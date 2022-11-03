using FluentAssertions;
using Sat.Recruitment.Application.Extensions;
using Sat.Recruitment.Domain.Dtos;
using Sat.Recruitment.Domain.ValueObjects;
using Sat.Recruitment.Test.Helpers.Factories;
using Xunit;

namespace Sat.Recruitment.Test.Tests.Infrastructure
{
    public class DtoExtensionsTest
    {
        [Fact]
        public void ToUserCreationDto_WithValidInput_ShouldGetValidEnumValue()
        {
            // Arrange
            User SUT = UserFactory.ValidUser;

            // Action
            UserCreationDto act = SUT.ToUserCreationDto();

            // Assertion
            act.Should().NotBeNull();
            act.Name.Should().Be(RecordHelper.Name);
            act.Email.Should().Be(RecordHelper.Email);
            act.Phone.Should().Be(RecordHelper.Phone);
            act.Address.Should().Be(RecordHelper.Address);
            act.UserType.Should().BeEquivalentTo(RecordHelper.UserType);
            act.Money.ToString().Should().Be(RecordHelper.Money);
        }
    }
}
