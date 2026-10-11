using CompanyApp.Models;
using CompanyApp.Repositories.Employees;

namespace CompanyApp.Repositories.Base
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        IRepository<Department> Departments { get; }
        int SaveChanges();
    }
}