using SNSModels;

namespace SNSBusinessLayer.Interfaces
{
    public interface IUserService
    {
        void RegisterUser(User user);

        User GetUserById(int id);

        List<User> GetAllUsers();
    }
}