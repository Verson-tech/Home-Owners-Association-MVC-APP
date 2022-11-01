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

        public Request AssignCategory()
        {
            var categoryList = GetCategories();
            var request = new Request();
            request.Categories = categoryList;
            return request;
        }

        public void DeleteRequest(Request request)
        {
            _conn.Execute("DELETE FROM MAINTENANCE WHERE RequestID = @id;", new { id = request.RequestID });
        }

        public IEnumerable<Request> GetAllRequests()
        {
            return _conn.Query<Request>("SELECT * FROM MAINTENANCE;");
        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT * FROM categories;");
        }
        public Request GetRequestAndCategories(int id)
        {
            var req = _conn.QuerySingle<Request>("SELECT * FROM MAINTENANCE WHERE REQUESTID = @id", new { id = id });
            req.Categories = GetCategories();
            return req;
        }
        public Request GetRequest(int id)
        {
            return _conn.QuerySingle<Request>("SELECT * FROM MAINTENANCE WHERE REQUESTID = @id", new { id = id });
        }

        public void InsertRequest(Request requestToInsert)
        {
            _conn.Execute("INSERT INTO maintenance (NAME, CATEGORYID, REQUESTDESC, REQUESTSTATUS,STARTDATE, ENDDATE, INITIATOR, ASSIGNEE) VALUES (@name, @categoryID, @requestdesc, @requeststatus,@startdate, @enddate, @initiator,@assignee);",
                 new { name = requestToInsert.Name, categoryID = requestToInsert.CategoryID, requestDESC = requestToInsert.RequestDESC, requestSTATUS = requestToInsert.RequestSTATUS, startDate = requestToInsert.StartDate, endDate =requestToInsert.EndDate, initiator = requestToInsert.Initiator, assignee = requestToInsert.Assignee });
        }

        public void UpdateRequest(Request request)
        {
            _conn.Execute("UPDATE maintenance SET Name = @name, CategoryID = @categoryid, RequestDESC = @requestdesc, RequestSTATUS = @requeststatus,StartDate = @startdate , EndDate = @enddate, Initiator = @initiator, Assignee = @assignee WHERE RequestID = @id",
                new { name = request.Name, categoryid = request.CategoryID, requestdesc = request.RequestDESC, requeststatus = request.RequestSTATUS, startdate= request.StartDate, enddate = request.EndDate, initiator = request.Initiator, assignee = request.Assignee, id = request.RequestID });
        }
    }
}
