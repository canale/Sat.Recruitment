using Sat.Recruitment.Domain.Guards;

namespace Sat.Recruitment.Domain.ValueObjects
{
    public class Money : ValueObject<Money>
    {
        public decimal Value { get; }

        public Money(decimal money)
        {
            Value = money;
        }

        protected override bool CompareEquality(Money other)
            => Value == other.Value;

        protected override int GetHashCodeCore()
            => Value.GetHashCode();

        public static implicit operator decimal(Money money) => money.Value;
        public static implicit operator Money(decimal money) => new Money(money);
    }
}
