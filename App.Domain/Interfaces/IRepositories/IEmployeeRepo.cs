using App.Domain.Entities;
using App.Domain.Models;

namespace App.Domain.Interfaces.IRepositories
{
    public interface IEmployeeRepo : IBaseRepository<Employee, int>
    {
        public Task<List<EmployeeModel>> GetAllEmployeeAsync();
        public Task<EmployeeModel> GetEmployeeByIdAsync(int id);       
    }
}
