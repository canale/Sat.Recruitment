using Sat.Recruitment.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;

namespace Sat.Recruitment.Application.Extensions
{
    internal static class UserExtensions
    {
        internal static bool HasDuplicates(this IEnumerable<User> users, User target) => users.Any(u => target.IsDuplicated(u));
    }
}
