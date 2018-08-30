using System.Linq;
using Newco.EmployeeDirectory.Core.Entities;

namespace Newco.EmployeeDirectory.Core.Data
{
    public static class DbInitialiser
    {
        public static void Initialise(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}



