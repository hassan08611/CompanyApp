using CompanyApp.Models;
using CompanyApp.Repositories.Employees;

namespace CompanyApp.Repositories.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IEmployeeRepository Employees { get; }
        public IRepository<Department> Departments { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Employees = new EmployeeRepository(_context);
            Departments = new Repository<Department>(_context);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}