using Edigama.Models;


namespace Edigama.DAL.Interfaces
{
    public interface IUserDAL
    {
        public IEnumerable<User> GetUsers();
        public User GetUserById(int id);
        public IEnumerable<User> GetUsersByName(string name);
        public User GetUserByEmail(string email);
        public Task<User> GetUserByEmailAsync(string email);
    }
}
