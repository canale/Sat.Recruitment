using System;
using System.Collections.Generic;
using System.Diagnostics;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Dtos;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.ValueObjects;

namespace Sat.Recruitment.Application.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRewardApplicationService _rewardApplicationService;

        public UserApplicationService(IUserRepository userRepository, IRewardApplicationService rewardApplicationService)
        {
            _userRepository = userRepository;
            _rewardApplicationService = rewardApplicationService;
        }

        public Result CreateUser(UserCreationDto dto)
        {
            var newUser = new User(
                dto.Name,
                dto.Email,
                dto.Address,
                dto.Phone,
                dto.UserType.ToUserType(),
                dto.Money
            );

            newUser = _rewardApplicationService.AddRewardToUser(newUser);


            try
            {
                IEnumerable<User> users = _userRepository.GetAll();
                var isDuplicated = false;
                foreach (var user in users)
                {
                    if (user.Email == newUser.Email || user.Phone == newUser.Phone)
                    {
                        isDuplicated = true;
                    }
                    else if (user.Name == newUser.Name)
                    {
                        if (user.Address == newUser.Address)
                        {
                            isDuplicated = true;
                            throw new Exception("User is duplicated");
                        }

                    }
                }

                if (!isDuplicated)
                {
                    Debug.WriteLine("User Created");

                    return new Result()
                    {
                        IsSuccess = true,
                        Errors = "User Created"
                    };
                }
                else
                {
                    Debug.WriteLine("The user is duplicated");

                    return new Result()
                    {
                        IsSuccess = false,
                        Errors = "The user is duplicated"
                    };
                }
            }
            catch
            {
                Debug.WriteLine("The user is duplicated");
                return new Result()
                {
                    IsSuccess = false,
                    Errors = "The user is duplicated"
                };
            }

            return new Result()
            {
                IsSuccess = true,
                Errors = "User Created"
            };

            return new Result()
            {
                IsSuccess = true,
                Errors = "User Created"
            };
        }
    }
}
