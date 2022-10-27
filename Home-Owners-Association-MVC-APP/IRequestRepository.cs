using Home_Owners_Association_MVC_APP.Models;

namespace Home_Owners_Association_MVC_APP
{
    public interface IRequestRepository
    {
        public IEnumerable<Request> GetAllRequests();
    }
}
