using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.Guards;

namespace Sat.Recruitment.Domain.ValueObjects
{
    public class User
    {
        public Name Name { get; }
        public Email Email { get; }
        public Address Address { get; }
        public Phone Phone { get; }
        public UserType UserType { get; }
        public Money Money { get; private set; }


        public User(Name name, Email email, Phone phone, Address address, UserType userType, Money money)
        {
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            UserType = userType;
            Money = money;
        }

        /// <summary>
        /// Allows to add reward by a percentage of users Money.
        /// </summary>
        /// <param name="percentage">Percentage of current Money that will be added to the User assets.</param>
        public User AddRewardByPercentage(decimal percentage)
        {
            Guard.For(percentage).IsNegative();

            var reward = Money * (percentage / 100);
            Money = Money + reward;

            return this;
        }

        /// <summary>
        /// Allows to determine if two User instances are equivalents
        /// </summary>
        /// <param name="other">Second User instance which will be compared.</param>
        /// <returns>Retrieves a bool value indicating if the other User instance is equivalent or not. True if it is or false if not.</returns>
        public bool IsDuplicated(User other)
            =>  (Email == other.Email || Phone == other.Phone)
                || (Name == other.Name && Address == other.Address);

        
    }
}
