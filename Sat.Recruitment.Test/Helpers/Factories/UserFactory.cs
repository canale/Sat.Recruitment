using Sat.Recruitment.Domain.Dtos;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.ValueObjects;
using System;
using System.Security.Policy;

namespace Sat.Recruitment.Test.Helpers.Factories
{
    internal static class UserFactory
    {
        internal readonly static User ValidUser = new User(RecordHelper.Name, RecordHelper.Email, RecordHelper.Phone, RecordHelper.Address, UserType.SuperUser, int.Parse(RecordHelper.Money));

        internal readonly static UserCreationDto ValidUserCreationDto = new UserCreationDto{
            Name = RecordHelper.Name,
            Email = RecordHelper.Email,
            Phone = RecordHelper.Phone,
            Address = RecordHelper.Address,
            UserType = UserType.SuperUser.ToStringFormat(), 
            Money = int.Parse(RecordHelper.Money)
        };

        internal static User GetValidWithMoney(decimal money)
            => new User(
                RecordHelper.Name, 
                RecordHelper.Email, 
                RecordHelper.Phone, 
                RecordHelper.Address, 
                UserType.SuperUser, 
                money);

        internal static User GetWith(
                                    Name name = null, 
                                    Email email = null, 
                                    Phone phone = null, 
                                    Address address = null, 
                                    UserType userType = default, 
                                    Money money = null)
          => new User(
                    name ?? RecordHelper.Name,
                    email ?? RecordHelper.Email,
                    phone ?? RecordHelper.Phone,
                    address ?? RecordHelper.Address,
                    (userType == default) ? UserType.SuperUser : userType,
                    money ?? money);
    }
}
