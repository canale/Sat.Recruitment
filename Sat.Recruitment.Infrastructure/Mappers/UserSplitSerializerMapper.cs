using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.ValueObjects;
using Sat.Recruitment.Infrastructure.Contracts;

namespace Sat.Recruitment.Infrastructure.Mappers
{
    public class UserSplitSerializerMapper : IDataSerializerMapper<User>
    {
        public char Separator => ',';

        public User Serialize(string[] fields)
            =>  new User
            (
                fields[0],
                fields[1],
                fields[2],
                fields[3],
                fields[4].ToUserType(),
                decimal.Parse(fields[5])
            ) ;

        public string[] Deserialize(User source)
            => new string[]
            {
                source.Name,
                source.Email,
                source.Phone,
                source.Address,
                source.UserType.ToStringFormat(),
                source.Money.Value.ToString()
            };
    }
}
