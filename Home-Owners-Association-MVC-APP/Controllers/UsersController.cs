using Microsoft.AspNetCore.Mvc;

namespace Home_Owners_Association_MVC_APP.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
