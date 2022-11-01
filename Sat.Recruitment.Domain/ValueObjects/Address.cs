using Sat.Recruitment.Domain.Guards;

namespace Sat.Recruitment.Domain.ValueObjects
{
    public class Address : SingleStringValueObject
    {
        public Address(string email):base(email)
        {
        }

        public static implicit operator string(Address address) => address.Value;
        public static implicit operator Address(string address) => new Address(address);
    }
}
