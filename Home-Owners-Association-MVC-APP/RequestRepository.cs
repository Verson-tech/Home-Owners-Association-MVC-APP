using Dapper;
using Home_Owners_Association_MVC_APP.Models;
using System.Data;

namespace Home_Owners_Association_MVC_APP
{
    public class RequestRepository : IRequestRepository
    {
        private readonly IDbConnection _conn;
        public RequestRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Request> GetAllRequests()
        {
            return _conn.Query<Request>("SELECT * FROM MAINTENANCE;");
        }

        public Request GetRequest(int id)
        {
            return _conn.QuerySingle<Request>("SELECT * FROM MAINTENANCE WHERE REQUESTID = @id", new { id = id });
        }

        public void UpdateRequest(Request request)
        {
            _conn.Execute("UPDATE maintenance SET Name = @name, CategoryID = @categoryid, RequestDESC = @requestdesc, RequestSTATUS = @requeststatus, EndDate = @enddate, Initiator = @initiator, Assignee = @assignee WHERE ProductID = @id",
                new { name = request.Name, categoryid = request.CategoryID, requestdesc = request.RequestDESC, requeststatus = request.RequestSTATUS, enddate = request.EndDate, initiator = request.Initiator, assignee = request.Assignee, id = request.RequestID });
        }
    }
}
