using Home_Owners_Association_MVC_APP.Models;
using Microsoft.AspNetCore.Mvc;

namespace Home_Owners_Association_MVC_APP.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestRepository repo;

        public RequestController(IRequestRepository repo)
        {
            this.repo = repo;
        }


        public IActionResult Index()
        {
            var requests = repo.GetAllRequests();
            return View(requests);           
        }

        public IActionResult ViewRequest(int id)
        {
            var request = repo.GetRequest(id);
            return View(request);
        }

        public IActionResult UpdateRequest(int id)
        {
            Request req = repo.GetRequest(id);
            if (req == null)
            {
                return View("RequestNotFound");
            }
            return View(req);
        }

        public IActionResult UpdateRequestToDatabase(Request request)
        {
            repo.UpdateRequest(request);

            return RedirectToAction("ViewRequest", new { id = request.RequestID });
        }
    }
}
