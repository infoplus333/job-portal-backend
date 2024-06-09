using JobPortal.Model;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Database
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext (DbContextOptions options) : base (options)
        {

        }
        public DbSet<Employee> Employees { get; set; }

    }
}
