using SNSDataAccessLayer.Contexts;
using SNSDataAccessLayer.Interfaces;
using SNSModels;

namespace SNSDataAccessLayer.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NotificationSystemContext context;

        public UserRepository(NotificationSystemContext context)
        {
            this.context = context;
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);

            context.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return context.Users.FirstOrDefault(u => u.Id == id)!;
        }
    }
}