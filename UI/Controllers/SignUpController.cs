using Edigama.DAL.Implementation;
using Edigama.DAL.Interfaces;
using Edigama.Models;
using Microsoft.AspNetCore.Mvc;

namespace Edigama.UI.Controllers
{
    public class SignUpController:Controller
    {
        private IUserDAL _user;

        [Route("/SignUp/Signup")]
        public IActionResult Signup()
        {            
            return View("/UI/Views/SignUp/Signup.cshtml");      
        }


        
        public IActionResult AddUser([FromForm]string name,[FromForm]string email,[FromForm]string password)
        {
            using(var context = new EdigamaDbContext())
            {
                _user = new UserDAL();
                if(_user.GetUserByEmail(email) == null)
                {                                
                    context.Users.Add(new User { Name = name,Email = email,Password = password });
                    context.SaveChanges();
                    TempData["MessageForSignUp"] = "OK";
                    Response.Cookies.Append(HomeController.cookieKey, name);
                    return View("/UI/Views/SignUp/Signup.cshtml");
                }

                TempData["MessageForSignUp"] = "ERROR";
                return View("/UI/Views/SignUp/Signup.cshtml");
                 
            }
        }


    }
}
