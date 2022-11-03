using Sat.Recruitment.Domain.Guards;
using System;

namespace Sat.Recruitment.Domain.Helpers
{
    public static class EmailUtils
    {
        public static string NormalizeEmailAddress(string target)
        {
            Guard.For(target)
                .IsNullOrEmpty()
                .NotContains("@");

            //Normalize Email
            var aux = target.Split('@', StringSplitOptions.RemoveEmptyEntries);
            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);
         
            return $"{aux[0]}@{aux[1]}";
        }
    }
}
