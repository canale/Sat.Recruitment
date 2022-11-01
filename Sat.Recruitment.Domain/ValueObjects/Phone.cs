namespace Sat.Recruitment.Domain.ValueObjects
{
    public class Phone : SingleStringValueObject
    {
        public Phone(string phone):base(phone)
        {
        }

        public static implicit operator string(Phone phone) => phone.Value;
        public static implicit operator Phone(string phone) => new Phone(phone);
    }
}
