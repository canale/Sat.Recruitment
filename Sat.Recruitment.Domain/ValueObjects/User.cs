using System.Net;
using Sat.Recruitment.Domain.Enums;

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


        public User(Name name, Email email, Address address, Phone phone, UserType userType, Money money)
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
            var reward = Money * percentage;
            Money = Money + reward;

            return this;
        }
    }
}
