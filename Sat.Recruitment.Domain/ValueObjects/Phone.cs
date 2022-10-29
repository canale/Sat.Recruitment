using Sat.Recruitment.Domain.Guards;

namespace Sat.Recruitment.Domain.ValueObjects
{
    public class Phone : ValueObject<Phone>
    {
        public string Value { get; }

        public Phone(string phone)
        {
            Guard.For(phone).IsNullOrEmpty();
            Value = phone;
        }

        protected override bool EqualsCore(Phone other)
            => Value == other.Value;

        protected override int GetHashCodeCore()
            => Value.GetHashCode();

        public static implicit operator string(Phone phone) => phone.Value;
        public static implicit operator Phone(string phone) => new Phone(phone);
    }
}
