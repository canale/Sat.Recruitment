using FluentAssertions;
using Sat.Recruitment.Domain.Helpers;
using System;
using Xunit;

namespace Sat.Recruitment.Test.Tests.Core.Domain
{
    public class EmailUtilsTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]

        public void Constructor_WithNullOrEmptyArgumrntFormat_ShouldThrowException(string emailAddress)
        {
            // Arrange

            // Action
            Action act = () => EmailUtils.NormalizeEmailAddress(emailAddress);

            // Assertion
            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Theory]
        [InlineData("abc-dmail.com")]
        [InlineData("abc.defmail.com")]
        [InlineData("abcmail.com")]
        [InlineData("abc_defmail.com")]
        [InlineData("abc.defmail-archive.com")]
        [InlineData("ab.c.defmail.c.om")]
        [InlineData("ab+cdefmail.c.om")]
        [InlineData("ab+c.defmail.c.om")]
        [InlineData("abc.de+fmail.c.om")]

        public void Constructor_WithInvalidArgumrntFormat_ShouldThrowException(string emailAddress)
        {
            // Arrange

            // Action
            Action act = () => EmailUtils.NormalizeEmailAddress(emailAddress);

            // Assertion
            act.Should().ThrowExactly<ArgumentException>();
        }

        [Theory]
        [InlineData("abc-d@mail.com", "abc-d@mail.com")]
        [InlineData("abc.def@mail.com", "abcdef@mail.com")]
        [InlineData("abc@mail.com", "abc@mail.com")]
        [InlineData("abc_def@mail.com", "abc_def@mail.com")]
        [InlineData("abc.def@mail.cc", "abcdef@mail.cc")]
        [InlineData("abc.def@mail-archive.com", "abcdef@mail-archive.com")]
        [InlineData("abc.def@mail.c.om", "abcdef@mail.c.om")]
        [InlineData("ab.c.def@mail.c.om", "abcdef@mail.c.om")]
        [InlineData("ab+cdef@mail.c.om", "ab@mail.c.om")]
        [InlineData("ab+c.def@mail.c.om", "ab@mail.c.om")]
        [InlineData("abc.de+f@mail.c.om", "abcde+@mail.c.om")]
        public void Constructor_WithValidArgumrntFormat_ShouldGetEmail(string emailAddress, string normalized)
        {
            // Arrange

            // Action
            string act = EmailUtils.NormalizeEmailAddress(emailAddress);

            // Assertion
            act.Should().Be(normalized);
        }
    }
}
