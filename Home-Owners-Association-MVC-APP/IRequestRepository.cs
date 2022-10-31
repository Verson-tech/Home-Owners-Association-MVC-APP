using Home_Owners_Association_MVC_APP.Models;

namespace Home_Owners_Association_MVC_APP
{
    public interface IRequestRepository
    {
        public IEnumerable<Request> GetAllRequests();
        public Request GetRequest(int id);
        public Request GetRequestAndCategories(int id);
        public void UpdateRequest(Request request);
        public void InsertRequest(Request requestToInsert);
        public IEnumerable<Category> GetCategories();
        public Request AssignCategory();
        public void DeleteRequest(Request request);
    }
}
