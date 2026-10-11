using CompanyApp.Models;
using CompanyApp.Repositories.Base;

namespace CompanyApp.Repositories.Employees
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        IEnumerable<Employee> GetAllWithDepartment();
        Employee? GetByIdWithDepartment(int id);
    }
}