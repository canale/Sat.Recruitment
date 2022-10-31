using Sat.Recruitment.Domain.Dtos;

namespace Sat.Recruitment.Domain.Contracts
{
    public interface IUserApplicationService
    {
        ResultDto CreateUser(UserCreationDto dto);
    }


    public class ResultDto
    {
        public bool IsSuccess { get; set; }
        public string Errors { get; set; }
    }
}
