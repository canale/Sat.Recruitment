using FluentAssertions;
using Sat.Recruitment.Domain.ValueObjects;
using Sat.Recruitment.Infrastructure.Mappers;
using Sat.Recruitment.Test.Helpers.Factories;
using System;
using Xunit;


namespace Sat.Recruitment.Test.Tests.Infrastructure
{
    public class UserSplitSerializerMapperTest: BaseTest<UserSplitSerializerMapper>
    {

        [Fact]
        public void Serialize_WithValidFields_ShouldGetValidResult()
        {
            // Arrange
            string[] fields = RecordHelper.UserRecord.Split(RecordHelper.Separator);

            var SUT = this.CreateSUT();

            // Action
            User act = SUT.Serialize(fields);

            // Assertion
            act.Should().NotBeNull();
            act.Should().BeEquivalentTo(UserFactory.ValidUser);
        }

        [Fact]
        public void Deserialize_WithValidInput_ShouldGetValidFields()
        {
            // Arrange
            string[] fields = RecordHelper.UserRecord.Split(RecordHelper.Separator);

            var SUT = this.CreateSUT();

            // Action
            string[] act = SUT.Deserialize(UserFactory.ValidUser);

            // Assertion
            act.Should().NotBeNull();
             act.Should().Equal(fields, (s1, s2) => string.Equals(s1, s2, StringComparison.OrdinalIgnoreCase));
           //act.Should().AllBeEquivalentTo(fields);
        }
    }
}
