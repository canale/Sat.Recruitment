namespace Sat.Recruitment.Domain.ValueObjects
{
    public abstract class ValueObject<TValueObject>
    where  TValueObject : class
    {
        public override bool Equals(object obj)
        {
            if (!(obj is TValueObject valueObject))
                return false;

            return GetType() == obj.GetType() && EqualsCore(valueObject);
        }

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        public static bool operator ==(ValueObject<TValueObject> val1, ValueObject<TValueObject> val2)
        {
            if (ReferenceEquals(val1, null) && ReferenceEquals(val2, null))
                return true;

            if (ReferenceEquals(val1, null) || ReferenceEquals(val2, null))
                return false;

            return val1.Equals(val2);
        }

        public static bool operator !=(ValueObject<TValueObject> val1, ValueObject<TValueObject> val2)
        {
            return !(val1 == val2);
        }


        protected abstract bool EqualsCore(TValueObject other);

        protected abstract int GetHashCodeCore();
    }
}
