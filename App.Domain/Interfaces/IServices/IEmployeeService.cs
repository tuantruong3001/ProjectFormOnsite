using App.Domain.Entities;
using App.Domain.Models;

namespace App.Domain.Interfaces.IServices
{
    public interface IEmployeeService : IBaseService<Employee, int>
    {
        public Task<List<EmployeeModel>> GetAllEmployeeAsync();
        public Task<EmployeeModel> GetEmployeeByIdAsync(int id);
    }
}
