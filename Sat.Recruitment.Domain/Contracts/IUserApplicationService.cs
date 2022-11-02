using Sat.Recruitment.Domain.Dtos;

namespace Sat.Recruitment.Domain.Contracts
{
    public interface IUserApplicationService
    {
        Result<UserCreationDto> CreateUser(UserCreationDto dto);
    }
}
