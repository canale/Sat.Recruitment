using Sat.Recruitment.Domain.Guards;

namespace Sat.Recruitment.Domain.ValueObjects
{
    public class Address : ValueObject<Address>
    {
        public string Value { get; }

        public Address(string email)
        {
            Guard.For(email).IsNullOrEmpty();
            Value = email;
        }

        protected override bool EqualsCore(Address other)
            => Value == other.Value;

        protected override int GetHashCodeCore()
            => Value.GetHashCode();


        public static implicit operator string(Address address) => address.Value;
        public static implicit operator Address(string address) => new Address(address);
    }
}
