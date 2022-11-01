using Sat.Recruitment.Domain.Guards;

namespace Sat.Recruitment.Domain.ValueObjects
{
    public abstract class SingleStringValueObject : ValueObject<SingleStringValueObject>   
    {
        private readonly bool _ignoreCaseComparision;

        public string Value { get; }

        public SingleStringValueObject(string value, bool ignoreCaseComparision = true)
        {
            Guard.For(value).IsNullOrEmpty();
            Value = value;
            this._ignoreCaseComparision = ignoreCaseComparision;
        }

        protected override bool CompareEquality(SingleStringValueObject other)
            => _ignoreCaseComparision 
            ? Value.ToLower() == other.Value.ToLower()
            : Value == other.Value;

        protected override int GetHashCodeCore()
            => Value.GetHashCode();


        public static implicit operator string(SingleStringValueObject target) => target.Value;
    }
}
