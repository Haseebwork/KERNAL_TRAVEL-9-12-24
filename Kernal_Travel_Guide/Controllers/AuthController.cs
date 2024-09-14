using Kernal_Travel_Guide.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;

namespace Kernal_Travel_Guide.Controllers
{
    public class AuthController : Controller
    {
        private readonly KernalTravelGuideContext db;

        public AuthController(KernalTravelGuideContext _db)
        {
            db = _db;
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(User user)
        {
            var checkUser = db.Users.FirstOrDefault(u => u.Email == user.Email);
            if (checkUser == null)
            {
                var hasher = new PasswordHasher<string>();
                var hashPassword = hasher.HashPassword(user.Email, user.Password);
                user.Password = hashPassword;
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.msg = "User already registered. Please login.";
                return View();
            }

        }


        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Login(string email, string password)
        {
            bool IsAuthenticated = false;

            ClaimsIdentity identity = null;
            string controller = "";
            var checkUser = db.Users.FirstOrDefault(u => u.Email == email);
            var checkAdmin = db.Admins.FirstOrDefault(u => u.Email == email);
            if (checkUser != null)
            {
                var hasher = new PasswordHasher<string>();
                var verifyPass = hasher.VerifyHashedPassword(email, checkUser.Password, password);

                if (verifyPass == PasswordVerificationResult.Success)
                {
                    identity = new ClaimsIdentity(new[]
              {
                    new Claim(ClaimTypes.Name ,checkUser.Name),
                    new Claim(ClaimTypes.Role ,"User"),

                }
             , CookieAuthenticationDefaults.AuthenticationScheme);
                    IsAuthenticated = true;
                    controller = "Home";
                    HttpContext.Session.SetInt32("UserID", checkUser.UserId);
                    HttpContext.Session.SetString("UserEmail", checkUser.Email);

                }
                else
                {
                    ViewBag.msg = "Invalid Credentials";
                    return View();
                }



            }

            else if (checkAdmin != null) {
                var hasher = new PasswordHasher<string>();
                var verifyPass = hasher.VerifyHashedPassword(email, checkAdmin.Password, password);
                if (verifyPass == PasswordVerificationResult.Success)
                {
                    identity = new ClaimsIdentity(new[]
                 {
                    new Claim(ClaimTypes.Name ,checkAdmin.Username),
                    new Claim(ClaimTypes.Role ,"Admin"),

                }
                , CookieAuthenticationDefaults.AuthenticationScheme);
                    IsAuthenticated = true;
                    controller = "Admin";

                    HttpContext.Session.SetInt32("UserID", checkAdmin.Id);
                    HttpContext.Session.SetString("UserEmail", checkAdmin.Email);
                }

                else
                {
                    ViewBag.msg = "Invalid Credentials";
                    return View();
                }
            }
            if (IsAuthenticated)
            {
                var principal = new ClaimsPrincipal(identity);

                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToAction("Index", controller);
            }
            else
            {
                ViewBag.msg = "Lgoin Failed";
                return View();

            } 
           


        }




        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserID");
            HttpContext.Session.Remove("UserEmail");

            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }

    }
}