using System.Collections.Generic;
using Sat.Recruitment.Domain.Contracts;
using Sat.Recruitment.Domain.ValueObjects;
using Sat.Recruitment.Infrastructure.Contracts;

namespace Sat.Recruitment.DataAccess.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDataLoader _dataLoader;
        private readonly IDataSerializer<User> _dataSerializer;
        // TODO: Should be improved.
        private static List<User> _users;

        public UserRepository(IDataLoader dataLoader, IDataSerializer<User> dataSerializer)
        {
            _dataLoader = dataLoader;
            _dataSerializer = dataSerializer;
        }

        public void AddsUser(User user)
        {
            //string newUser  = _dataSerializer.Deserialize(user);
            _users.Add(user);
        }

        public User[] GetAll()
        {
            if (_users is null)
            {
                _users = new List<User>();

                _dataLoader.LoadData(reader =>
                {
                    while (reader.Peek() >= 0)
                    {
                        var line = reader.ReadLineAsync().Result;
                        User user = _dataSerializer.Serialize(line);

                        _users.Add(user);
                    }
                });
            }

            return _users.ToArray();
        }

    }
}
