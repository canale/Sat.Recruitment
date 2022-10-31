using System;

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

        public static string ToStringFormat(this UserType target)
            => target switch
            {
                UserType.Normal => "normal",
                UserType.SuperUser => "superuser",
                UserType.Premium => "premium",
                _ => throw new InvalidOperationException()
            };

    }
}
