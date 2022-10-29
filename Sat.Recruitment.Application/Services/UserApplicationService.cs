using System;
using System.Collections.Generic;
using System.Diagnostics;
using Sat.Recruitment.Domain;
using Sat.Recruitment.Domain.Dtos;
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
            decimal.TryParse(dto.money, out decimal money);
            var newUser = new User
            {
                Name = dto.name,
                Email = dto.email,
                Address = dto.address,
                Phone = dto.phone,
                UserType = dto.userType,
                Money = money
            };

            if (newUser.UserType == "Normal")
            {
                if (newUser.Money > 100)
                {
                    var percentage = Convert.ToDecimal(0.12);
                    //If new user is normal and has more than USD100
                    var gif = decimal.Parse(dto.money) * percentage;
                    newUser.Money = newUser.Money + gif;
                }

                if (newUser.Money < 100)
                {
                    if (newUser.Money > 10)
                    {
                        var percentage = Convert.ToDecimal(0.8);
                        var gif = decimal.Parse(dto.money) * percentage;
                        newUser.Money = newUser.Money + gif;
                    }
                }
            }

            if (newUser.UserType == "SuperUser")
            {
                if (newUser.Money > 100)
                {
                    var percentage = Convert.ToDecimal(0.20);
                    var gif = decimal.Parse(dto.money) * percentage;
                    newUser.Money = newUser.Money + gif;
                }
            }

            if (newUser.UserType == "Premium")
            {
                if (newUser.Money > 100)
                {
                    var gif = decimal.Parse(dto.money) * 2;
                    newUser.Money = newUser.Money + gif;
                }
            }

            _dataLoader.LoadData(reader =>
            {

                //Normalize email
                var aux = newUser.Email.Split(new char[] { '@' }, StringSplitOptions.RemoveEmptyEntries);

                var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);

                aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

                newUser.Email = string.Join("@", new string[] { aux[0], aux[1] });

                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLineAsync().Result;

                    var user = new User
                    {
                        Name = line.Split(',')[0].ToString(),
                        Email = line.Split(',')[1].ToString(),
                        Phone = line.Split(',')[2].ToString(),
                        Address = line.Split(',')[3].ToString(),
                        UserType = line.Split(',')[4].ToString(),
                        Money = decimal.Parse(line.Split(',')[5].ToString()),
                    };

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
