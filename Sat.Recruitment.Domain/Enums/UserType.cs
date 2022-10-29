using System;
using System.Diagnostics;

namespace Sat.Recruitment.Domain.Enums
{
    public enum UserType
    {
        Normal,
        SuperUser,
        Premium
    }

    public static class UserTypeExtensions
    {
        public static UserType ToUserType(this string target)
        {
            string cleanTarget = target.Trim().ToLower();

            return cleanTarget switch
            {
                "normal" => UserType.Normal,
                "superuser" => UserType.SuperUser,
                "premium" => UserType.Premium,
                _ => throw new InvalidOperationException()
            };
        }
    }
}
