using Sat.Recruitment.Application.Extensions;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Dtos;
using Sat.Recruitment.Domain.Guards;
using Sat.Recruitment.Domain.ValueObjects;

namespace Sat.Recruitment.Application.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRewardService _rewardApplicationService;

        public UserApplicationService(IUserRepository userRepository, IRewardService rewardApplicationService)
        {
            _userRepository = userRepository;
            _rewardApplicationService = rewardApplicationService;
        }

        public Result<UserCreationDto> CreateUser(UserCreationDto dto)
        {
            Guard.For(dto).IsNull();

            User newUser = dto.ToUser();
            bool isDuplicated = _userRepository
                .GetAll()
                .HasDuplicates(newUser);

            if (isDuplicated)
            {
                return Result<UserCreationDto>.Failure(new Error("The user is duplicated", typeof(User)));
            }

            newUser = _rewardApplicationService.AddRewardToUser(newUser);
            _userRepository.AddsUser(newUser);

            return Result<UserCreationDto>.Succeed(newUser.ToUserCreationDto());
        }
    }
}
