using Microsoft.AspNetCore.Mvc;

namespace Home_Owners_Association_MVC_APP.Controllers
{
    public class OwnersLoginController : Controller
    {
        private readonly IRequestRepository repo;

        public OwnersLoginController(IRequestRepository repo)
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
