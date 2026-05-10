
using SNSModels;

namespace SNSDataAccessLayer
{
    public class UserRepository
    {
        List<User> UserList = new List<User>();

        public void SaveUser(User user)
        {
            UserList.Add(user);
        }

        public List<User> GetAllUsers()
        {
            return UserList;
        }

    }
}