using Edigama.BL.Interfaces;
using Edigama.DAL.Implementation;
using Edigama.DAL.Interfaces;
using Edigama.Models;


namespace Edigama.BL.Implementation
{
    public class UserBL:IUserBL
    {
        private IUserDAL _userDAL;

        public UserBL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public int? Authentificate(string email,string password)
        {
            foreach(var user in _userDAL.GetUsers())
            {
                if(user.Email==email && user.Password==password)
                {
                    return user.Id;
                }
            }
            return null;
        }
    }
}
