using Microsoft.EntityFrameworkCore;

namespace CompanyApp.Models
{
    public class ApplicationDbContext : DbContext
    {

        public DbSet<Department> Departments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}