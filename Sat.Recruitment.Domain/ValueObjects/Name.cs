using Sat.Recruitment.Domain.Guards;

namespace Sat.Recruitment.Domain.ValueObjects
{
    public class Name : ValueObject<Name>
    {
        public string Value { get; }

        public Name(string name)
        {
            Guard.For(name).IsNullOrEmpty();
            Value = name;
        }

        protected override bool EqualsCore(Name other)
            => Value == other.Value;

        protected override int GetHashCodeCore()
            => Value.GetHashCode();


        public static implicit operator string(Name name) => name.Value;
        public static implicit operator Name(string name) => new Name(name);
    }
}
