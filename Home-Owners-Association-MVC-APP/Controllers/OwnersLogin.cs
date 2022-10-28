using Microsoft.AspNetCore.Mvc;

namespace Home_Owners_Association_MVC_APP.Controllers
{
    public class OwnersLogin : Controller
    {
        private readonly IRequestRepository repo;

        public OwnersLogin(IRequestRepository repo)
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
