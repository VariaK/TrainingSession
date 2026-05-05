using System.Globalization;
using System.Collections.Generic;
using System.Linq;

namespace SimpleNotificationSystem
{
    internal class UserRepository : IRepository<string, User>
    {
        Dictionary<string, User> _User = new Dictionary<string, User>();

        public User Create(User item)
        {
            _User.Add(item.PhoneNumber,item);
            return item;
        }
        public User? GetDetails(string PhoneNumber)
        {
            if (_User.ContainsKey(PhoneNumber))
                return _User[PhoneNumber];
            return null;
        }

        public List<User> GetAll()
        {
            return _User.Values.ToList();
        }

        public User? Update(string PhoneNumber, User item)
        {
            var user = GetDetails(PhoneNumber);
            if (user == null)
                return null;

            _User[PhoneNumber] = item;
            return item;
        }

        public User? Delete(string PhoneNumber)
        {
            var user = GetDetails(PhoneNumber);
            if (user == null)
                return null;
            _User.Remove(PhoneNumber);
            return user;
        }

    }
}