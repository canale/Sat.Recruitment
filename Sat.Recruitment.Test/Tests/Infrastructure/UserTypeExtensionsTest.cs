using FluentAssertions;
using Sat.Recruitment.Domain.Enums;
using System;
using Xunit;

namespace Sat.Recruitment.Test.Tests.Infrastructure
{
    public class UserTypeExtensionsTest
    {
        [Theory]
        [InlineData("normal", UserType.Normal)]
        [InlineData("Normal", UserType.Normal)]
        [InlineData("NORMAL", UserType.Normal)]
        [InlineData(" normal", UserType.Normal)]
        [InlineData("normal ", UserType.Normal)]
        [InlineData("superuser", UserType.SuperUser)]
        [InlineData("Superuser", UserType.SuperUser)]
        [InlineData(" superuser", UserType.SuperUser)]
        [InlineData("superuser ", UserType.SuperUser)]
        [InlineData("SUPERUSER", UserType.SuperUser)]
        [InlineData("premium", UserType.Premium)]
        [InlineData("Premium", UserType.Premium)]
        [InlineData("PREMIUM", UserType.Premium)]
        [InlineData(" premium", UserType.Premium)]
        [InlineData("premium ", UserType.Premium)]
        public void ToUserType_WithValidInput_ShouldGetValidEnumValue(string input, UserType expected)
        {
            // Arrange

            // Action
            UserType act = input.ToUserType();

            // Assertion
            act.Should().Be(expected);
        }

        [Theory]
        [InlineData(" ")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("normalito")]
        [InlineData("premuum")]
        [InlineData("5254252")]
        [InlineData("norma2l")]
        [InlineData("norm al")]
        [InlineData("NORM al")]
        public void ToUserType_WithInvalidInput_ShouldThrowException(string input)
        {
            // Arrange

            // Action
            Action act = () => input.ToUserType();

            // Assertion
            act.Should().ThrowExactly<InvalidOperationException>();
        }


        [Theory]
        [InlineData( UserType.Normal, "normal"  )]
        [InlineData( UserType.SuperUser, "superuser")]
        [InlineData( UserType.Premium, "premium" )]
        public void ToStringFormat_WithValidInput_ShouldGetValidString(UserType input, string expected)
        {
            // Arrange

            // Action
            string act = input.ToStringFormat();

            // Assertion
            act.Should().Be(expected);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(100)]
        [InlineData(-1)]
        public void ToStringFormat_WithInvalidInput_ShouldThrowException(int input)
        {
            // Arrange

            // Action
            Action act = () => ((UserType) input).ToStringFormat();

            // Assertion
            act.Should().ThrowExactly<InvalidOperationException>();
        }
    }
}
