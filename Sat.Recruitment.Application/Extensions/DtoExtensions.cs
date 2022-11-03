using Sat.Recruitment.Domain.Dtos;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.ValueObjects;

namespace Sat.Recruitment.Application.Extensions
{
    public static class DtoExtensions
    {
        public static User ToUser(this UserCreationDto dto)
            => new User(
                dto.Name,
                dto.Email,
                dto.Phone,
                dto.Address,
                dto.UserType.ToUserType(),
                dto.Money
            );

        public static UserCreationDto ToUserCreationDto(this User user)
            => new UserCreationDto
            {
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                UserType = user.UserType.ToStringFormat(),
                Money = user.Money
            };
    }
}
