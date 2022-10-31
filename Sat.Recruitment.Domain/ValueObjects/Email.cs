using System;
using System.Text.RegularExpressions;
using Sat.Recruitment.Domain.Guards;

namespace Sat.Recruitment.Domain.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        private const string Pattern = @"^[\w-](([-\.]{0,1}[\w]))*(\w)*@([\w-]+\.)+[\w-]{2,4}$";
        private const RegexOptions Options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;

        public string Value { get; }

        public Email(string email)
        {
            Guard.For(email)
                .IsNullOrEmpty()
                .NotMatch( new Regex(Pattern, Options), "Invalid Email format");

            Value = Normalize(email);
        }

        protected override bool EqualsCore(Email other)
            => Value == other.Value;

        protected override int GetHashCodeCore()
            => Value.GetHashCode();

        private string Normalize(string target)
        {
            //Normalize Email
            var aux = target.Split('@', StringSplitOptions.RemoveEmptyEntries);
            var atIndex = aux[0].IndexOf("+", StringComparison.Ordinal);
            aux[0] = atIndex < 0 ? aux[0].Replace(".", "") : aux[0].Replace(".", "").Remove(atIndex);

            return string.Join("@", new string[] { aux[0], aux[1] });
        }

        public static implicit operator string(Email email) => email.Value;
        public static implicit operator Email(string email) => new Email(email);
    }
}
