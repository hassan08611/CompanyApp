using CompanyApp.Models;
using CompanyApp.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace CompanyApp.Repositories.Employees
{
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Employee> GetAllWithDepartment()
        {
            return _context.Employees.Include(e => e.Department).ToList();
        }

        public Employee? GetByIdWithDepartment(int id)
        {
            return _context.Employees
                .Include(e => e.Department)
                .FirstOrDefault(e => e.Id == id);
        }
    }
}