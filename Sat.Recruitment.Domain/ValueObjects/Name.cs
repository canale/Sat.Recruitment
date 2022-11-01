using Sat.Recruitment.Domain.Guards;

namespace Sat.Recruitment.Domain.ValueObjects
{
    public class Name : SingleStringValueObject
    {
        public Name(string name):base(name)
        {
        }

        public static implicit operator string(Name name) => name.Value;
        public static implicit operator Name(string name) => new Name(name);
    }
}
