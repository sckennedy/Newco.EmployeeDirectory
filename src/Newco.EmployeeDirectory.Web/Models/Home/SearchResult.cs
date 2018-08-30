using Microsoft.Net.Http.Headers;

namespace Newco.EmployeeDirectory.Web.Models.Home
{
    public class SearchResult
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
    }
}