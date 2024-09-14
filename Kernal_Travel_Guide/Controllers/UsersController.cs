using Microsoft.AspNetCore.Mvc;

namespace Kernal_Travel_Guide.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
