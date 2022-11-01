using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.ValueObjects;

namespace Sat.Recruitment.Test.Helpers.Factories
{
    internal static class UserFactory
    {
        public readonly static User Valid = new User(RecordHelper.Name, RecordHelper.Email, RecordHelper.Phone, RecordHelper.Address, UserType.SuperUser, int.Parse(RecordHelper.Money));
    }
}
