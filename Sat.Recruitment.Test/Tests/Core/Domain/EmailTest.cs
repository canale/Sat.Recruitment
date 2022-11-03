using FluentAssertions;
using Newtonsoft.Json.Linq;
using Sat.Recruitment.Domain.ValueObjects;
using System;
using Xunit;

namespace Sat.Recruitment.Test.Tests.Core.Domain
{
    public class EmailTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Constructor_WithNullOrEmptyArgument_ShouldThrowException(string emailAddress)
        {
            // Arrange

            // Action
            Action act = () => new Email(emailAddress);

            // Assertion
            act.Should().ThrowExactly<ArgumentNullException>();
        }

        [Theory]
        [InlineData("ab")]
        [InlineData("abfiadh.dfaad.adfa")]
        [InlineData("123dfsd.dfaad.adfa")]
        [InlineData("123dfsd@.dfaad.adfa")]
        [InlineData("123dfsd@dfaad.")]
        [InlineData("123dfsd@dfaad")]
        [InlineData("123df!sd@dfaad.aaa")]
        [InlineData("123df@sd@aa.aaa")]
        [InlineData("123dfsd.@1dfaad.adfa.dfa")]
        [InlineData("ab..c@mail.com")]
        [InlineData("abc-@mail.com")]
        [InlineData(".abc@mail.com")]
        [InlineData("abc#def@mail.com")]
        [InlineData("abc.def@mail.c")]
        [InlineData("abc.def@mail#archive.com")]
        [InlineData("abc.def@mail")]
        [InlineData("abc.def@mail..com")]
        public void Constructor_WithInvalidArgumrntFormat_ShouldThrowException(string emailAddress)
        {
            // Arrange

            // Action
            Action act = () => new Email(emailAddress);

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
        public void Constructor_WithValidArgumrntFormat_ShouldGetEmail(string emailAddress, string normalized)
        {
            // Arrange

            // Action
            Email act = new Email(emailAddress);

            // Assertion
            act.Value.Should().Be(normalized);
        }
    }
}
