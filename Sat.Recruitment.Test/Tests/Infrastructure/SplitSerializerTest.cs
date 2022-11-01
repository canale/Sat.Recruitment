using FluentAssertions;
using Sat.Recruitment.Domain.ValueObjects;
using Sat.Recruitment.Infrastructure.Contracts;
using Sat.Recruitment.Infrastructure.Implementations;
using Sat.Recruitment.Test.Helpers.Factories;
using Xunit;

namespace Sat.Recruitment.Test.Tests.Infrastructure
{
    public class SplitSerializerTest : BaseTest<SplitSerializer<User>>
    {
        [Fact]
        public void Serialize_WithValidRecord_ShouldGetValidResult()
        {
            // Arrange
            string[] fields = RecordHelper.UserRecord.Split(RecordHelper.Separator);

            var dataSerializerMapper = AddFromInterface<IDataSerializerMapper<User>>();

            dataSerializerMapper.Setup(mock => mock.Serialize(fields))
                .Returns(UserFactory.Valid);

            dataSerializerMapper.SetupGet(mock => mock.Separator).Returns(RecordHelper.Separator);

            var SUT = this.CreateSUT();

            // Action
            User act = SUT.Serialize(RecordHelper.UserRecord);

            // Assertion
            act.Should().NotBeNull();
            act.Should().BeEquivalentTo(UserFactory.Valid);
        }


        [Fact]
        public void Deserialize_WithValidInput_ShouldGetValidRecord()
        {
            // Arrange
            string[] fields = RecordHelper.UserRecord.Split(RecordHelper.Separator);

            var dataSerializerMapper = AddFromInterface<IDataSerializerMapper<User>>();

            dataSerializerMapper
                .Setup(mock => mock.Deserialize(UserFactory.Valid))
                .Returns(fields);

            dataSerializerMapper.SetupGet(mock => mock.Separator).Returns(RecordHelper.Separator);

            var SUT = this.CreateSUT();

            // Action
            string act = SUT.Deserialize(UserFactory.Valid);

            // Assertion
            act.Should().NotBeNull();
            act.Should().BeEquivalentTo(RecordHelper.UserRecord);
        }
    }
}
