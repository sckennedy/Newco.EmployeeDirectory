using System.ComponentModel.DataAnnotations;
using Newco.EmployeeDirectory.Core.Entities;

namespace Newco.EmployeeDirectory.Web.Models.Home
{
    public class EmployeeDetail
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string MobilePhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Manager { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string DeskNumber { get; set; }
        public string Building { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }

        public static EmployeeDetail FromEmployeeObject(Employee e)
        {
            return new EmployeeDetail
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                PhoneNumber = e.PhoneNumber,
                MobilePhoneNumber = e.MobilePhoneNumber,
                JobTitle = e.JobTitle,
                Department = e.Department,
                Manager = e.Manager,
                Email = e.Email,
                DeskNumber = e.DeskNumber,
                Building = e.Building,
                Street = e.Street,
                City = e.City,
                State = e.State,
                PostCode = e.PostCode,
                Country = e.Country
            };
        }

    }
}