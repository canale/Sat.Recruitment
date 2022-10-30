using System.Collections.Generic;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.Enums;
using Sat.Recruitment.Domain.ValueObjects;
using Sat.Recruitment.Infrastructure.Contracts;

namespace Sat.Recruitment.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataLoader _dataLoader;
        private readonly List<User> _users = new List<User>();

        public UserRepository(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        public void AddsUser(User user)
        {
            _dataLoader.LoadData(reader =>
            {
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLineAsync().Result;

                    var user = new User
                    (
                        line.Split(',')[0],
                        line.Split(',')[1],
                        line.Split(',')[2],
                        line.Split(',')[3],
                        line.Split(',')[4].ToUserType(),
                        decimal.Parse(line.Split(',')[5])
                    );

                    _users.Add(user);
                }
            });
        }

        public IList<User> GetAll()
        {
            _dataLoader.LoadData(reader =>
            {
                while (reader.Peek() >= 0)
                {
                    var line = reader.ReadLineAsync().Result;

                    var user = new User
                    (
                        line.Split(',')[0],
                        line.Split(',')[1],
                        line.Split(',')[2],
                        line.Split(',')[3],
                        line.Split(',')[4].ToUserType(),
                        decimal.Parse(line.Split(',')[5])
                    );

                    _users.Add(user);
                }
            });
        }
    }
}
