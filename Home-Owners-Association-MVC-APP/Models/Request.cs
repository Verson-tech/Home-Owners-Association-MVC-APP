using System.Data.Common;

namespace Home_Owners_Association_MVC_APP.Models
{
    public class Request
    {

        public Request()
        {

        }
       // Adding properties to the class that corresponds with SQL Column Names
        public int RequestID { get; set; }
        public string? Name { get; set; }
        public string? CategoryID { get; set; }
        public string? RequestDESC { get; set; }
        public string? RequestSTATUS { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public string? Initiator { get; set; }
        public string Assignee { get; set; }

    }
}
