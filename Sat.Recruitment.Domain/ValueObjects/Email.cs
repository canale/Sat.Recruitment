using System;
using System.Text.RegularExpressions;
using Sat.Recruitment.Domain.Guards;
using Sat.Recruitment.Domain.Helpers;

namespace Sat.Recruitment.Domain.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        private const string Pattern = @"^[\w-](([-\.+]{0,1}[\w]))*(\w)*@([\w-]+\.)+[\w-]{2,4}$";
        private const RegexOptions Options = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;



        public string Value { get; }

        public Email(string email)
        {
            Guard.For(email)
                .IsNullOrEmpty()
                .NotMatch( new Regex(Pattern, Options), "Invalid Email format");

            Value = EmailUtils.NormalizeEmailAddress(email);
        }

        protected override bool CompareEquality(Email other)
            => Value.ToLower() == other.Value.ToLower();

        protected override int GetHashCodeCore()
            => Value.GetHashCode();


        public static implicit operator string(Email email) => email.Value;
        public static implicit operator Email(string email) => new Email(email);
    }
}
