using Edigama.BL.Implementation;
using Edigama.DAL.Interfaces;
using Edigama.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Edigama.DAL.Implementation
{
    public class UserDAL:IUserDAL
    {
        public IEnumerable<User> GetUsers()
        {
            using(var conntext = new EdigamaDbContext())
            {
                return conntext.Users;
            }
        }

        public User GetUserByEmail(string email)
        {
            using(var context = new EdigamaDbContext())
            {
                return context.Users.Where(u=>u.Email == email).FirstOrDefault();
            }
        }

        public User GetUserById(int id)
        {
            using(var context = new EdigamaDbContext())
            {
                return context.Users.Where(u=>u.Id == id).FirstOrDefault();
            }
        }

        public IEnumerable<User> GetUsersByName(string name)
        {
            using(var context = new EdigamaDbContext()) 
            {
                return context.Users.Where(u=>u.Name == name);
            }
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            using(var context = new EdigamaDbContext())
            {
                return await context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();
            }
        }
    }
}
