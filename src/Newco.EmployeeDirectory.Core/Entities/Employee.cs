using System.ComponentModel.DataAnnotations;

namespace Newco.EmployeeDirectory.Core.Entities
{
    /// <summary>
    /// The Employee database table representational model
    /// </summary>
    public class Employee
    {
        /// <summary>
        /// The primary key for the entity
        /// </summary>
        [Key]
        [StringLength(8)]
        public string Id { get; set; }

        [StringLength(256)]
        public string FirstName { get; set; }

        [StringLength(256)]
        public string LastName { get; set; }

        [StringLength(256)]
        public string PhoneNumber { get; set; }

        [StringLength(256)]
        public string MobilePhoneNumber { get; set; }

        [StringLength(256)]
        public string JobTitle { get; set; }

        [StringLength(256)]
        public string Department { get; set; }

        [StringLength(256)]
        public string Manager { get; set; }

        [EmailAddress]
        [StringLength(256)]
        public string Email { get; set; }

        [StringLength(256)]
        public string DeskNumber { get; set; }

        [StringLength(256)]
        public string Building { get; set; }

        [StringLength(256)]
        public string Street { get; set; }

        [StringLength(256)]
        public string City { get; set; }

        [StringLength(256)]
        public string State { get; set; }

        [StringLength(25)]
        public string PostCode { get; set; }

        [StringLength(256)]
        public string Country { get; set; }

        [StringLength(2560)]
        public string NormalisedName { get; set; }
    }
}