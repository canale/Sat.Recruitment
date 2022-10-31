﻿using Sat.Recruitment.Domain.Dtos;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.ValueObjects;

namespace Sat.Recruitment.Application.Extensions
{
    internal static class DtoExtensions
    {
        internal static User ToUser(this UserCreationDto dto)
            => new User(
                dto.Name,
                dto.Email,
                dto.Phone,
                dto.Address,
                dto.UserType.ToUserType(),
                dto.Money
            );
    }
}
