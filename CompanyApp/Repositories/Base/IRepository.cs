using CompanyApp.Models;

namespace CompanyApp.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        T? GetById(int id);
        IEnumerable<T> GetAll(int value);
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        object? GetAll();
        object GetAllWithDepartment();
        void Delete(IEnumerable<Department> department);
    }
}
