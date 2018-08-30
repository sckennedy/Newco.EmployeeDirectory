using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newco.EmployeeDirectory.Core.Entities;

namespace Newco.EmployeeDirectory.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        #region Public Properties

        public DbSet<Employee> Employees { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Default constructor expecting database options to be provided
        /// </summary>
        /// <param name="options">The database context options</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {   
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .Property(p => p.NormalisedName)
                .HasComputedColumnSql("LOWER([FirstName])+LOWER([LastName]) + ',' + LOWER([FirstName]) + ',' + LOWER([LastName]) + ',' + LOWER([Id]) + ',' + REPLACE([PhoneNumber], ' ', '') + ',' + REPLACE([MobilePhoneNumber], ' ', '')");

            base.OnModelCreating(modelBuilder);
        }
    }
}