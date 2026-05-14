using SNSBusinessLayer.Interfaces;
using SNSDataAccessLayer.Interfaces;
using SNSDataAccessLayer.Repositories;
using SNSModels;

namespace SNSBusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public List<User> GetAllUsers()
        {
            return userRepository.GetAllUsers();
        }

        public User GetUserById(int id)
        {
            return userRepository.GetUserById(id);
        }

        public void RegisterUser(User user)
        {
            userRepository.AddUser(user);
        }
    }
}