using Sat.Recruitment.Domain.Dtos;

namespace Sat.Recruitment.Domain
{
    public interface IUserApplicationService
    {
        Result CreateUser(UserCreationDto dto);
    }


    public class Result
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }
}
