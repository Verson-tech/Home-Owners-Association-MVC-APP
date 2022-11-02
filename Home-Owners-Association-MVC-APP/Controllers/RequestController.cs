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
            Request req = repo.GetRequestAndCategories(id);
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

        public IActionResult InsertRequest()
        {
            var req = repo.AssignCategoryAndStatus();
            return View(req);
        }

        public IActionResult InsertRequestToDatabase(Request requestToInsert)
        {
            repo.InsertRequest(requestToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteRequest(Request request)
        {
            repo.DeleteRequest(request);
            return RedirectToAction("Index");
        }
    }
}
