using Sat.Recruitment.Application.Extensions;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Dtos;
using Sat.Recruitment.Domain.Guards;
using Sat.Recruitment.Domain.ValueObjects;
using System.Linq;

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

        public ResultDto CreateUser(UserCreationDto dto)
        {
            Guard.For(dto).IsNull();

            User newUser = dto.ToUser();
            bool isDuplicated = _userRepository
                .GetAll()
                .HasDuplicated(newUser);

            if (isDuplicated)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Errors = "The user is duplicated",
                };
            }

            newUser = _rewardApplicationService.AddRewardToUser(newUser);
            _userRepository.AddsUser(newUser);

            return new ResultDto
            {
                IsSuccess = true,
                Errors = "User Created",
            };
        }
    }
}
