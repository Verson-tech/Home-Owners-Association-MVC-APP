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
    }
}
