using Edigama.Models;


namespace Edigama.BL.Interfaces
{

    public interface IUserBL
    {
        public int? Authentificate(string email, string password);
    }
}
