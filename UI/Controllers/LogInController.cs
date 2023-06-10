using Edigama.DAL.Implementation;
using Edigama.DAL.Interfaces;
using Edigama.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace Edigama.UI.Controllers
{
    public class LogInController:Controller
    {
        private IUserDAL _user;

        [Route("/LogIn/Login")]
        public IActionResult Login()
        {               
            return View("/UI/Views/LogIn/Login.cshtml");
        }


        
        public async Task<IActionResult> Loging([FromForm] string email,[FromForm] string password)
        {

            _user = new UserDAL();
            var user = await _user.GetUserByEmailAsync(email);

            if(user != null && user.Password == password)
            {       
                Response.Cookies.Append(HomeController.cookieKey, user.Name);
                return RedirectToAction("Index","Home");
            }

           
            TempData["MessageForLogIn"] = "ERROR";
            return View("/UI/Views/LogIn/Login.cshtml");
        }

    }
}
