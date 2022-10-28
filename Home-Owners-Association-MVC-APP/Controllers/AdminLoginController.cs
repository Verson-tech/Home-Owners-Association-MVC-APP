using Microsoft.AspNetCore.Mvc;

namespace Home_Owners_Association_MVC_APP.Controllers
{
    public class AdminLoginController : Controller
    {

        private readonly IRequestRepository repo;

        public AdminLoginController(IRequestRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var requests = repo.GetAllRequests();
            return View(requests);
        }
    }
}
