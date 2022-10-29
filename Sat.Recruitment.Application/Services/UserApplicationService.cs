using System;
using System.Collections.Generic;
using System.Diagnostics;
using Sat.Recruitment.Domain;
using Sat.Recruitment.Domain.Dtos;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.ValueObjects;
using Sat.Recruitment.Infrastructure.Contracts;

namespace Sat.Recruitment.Application.Services
{
    public class UserApplicationService : IUserApplicationService
    {
        private readonly IDataLoader _dataLoader;
        private readonly List<User> _users = new List<User>();

        public UserApplicationService(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        public Result CreateUser(UserCreationDto dto)
        {
            var newUser = new User(
                dto.name,
                dto.email,
                dto.address,
                dto.phone,
                dto.userType.ToUserType(),
                dto.money
            );

            switch (newUser.UserType)
            {
                case UserType.Normal:
                {
                    //If new user is normal and has more than USD100
                    if (newUser.Money > 100)
                    {
                        newUser.AddRewardByPercentage(0.12m);
                    }
                    else if (newUser.Money < 100 && newUser.Money > 10)
                    {
                        newUser.AddRewardByPercentage(0.8m);
                    }

                    break;
                }
                case UserType.SuperUser:
                {
                    if (newUser.Money > 100)
                    {
                        newUser.AddRewardByPercentage(0.20m);
                    }

                    break;
                }
                case UserType.Premium:
                {
                    if (newUser.Money > 100)
                    {
                        newUser.AddRewardByPercentage(2);
                    }

                    break;
                }
            }

            _dataLoader.LoadData(reader =>
            {
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLineAsync().Result;

                    var user = new User
                    (
                        line.Split(',')[0],
                        line.Split(',')[1],
                        line.Split(',')[2],
                         line.Split(',')[3],
                        line.Split(',')[4].ToUserType(),
                        decimal.Parse(line.Split(',')[5])
                    );

                    _users.Add(user);
                }
            });

            try
            {
                var isDuplicated = false;
                foreach (var user in _users)
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
