using SNSModels;

namespace SNSDataAccessLayer.Interfaces
{
    public interface IUserRepository
    {
        void AddUser(User user);

        User GetUserById(int id);

        List<User> GetAllUsers();
    }
}