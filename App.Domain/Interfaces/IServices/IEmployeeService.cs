using App.Domain.Entities;
using App.Domain.Models;

namespace App.Domain.Interfaces.IServices
{
    public interface IEmployeeService : IBaseService<Employee, int>
    {
        Task<List<EmployeeModel>> GetAllEmployeeAsync();
        Task<EmployeeModel> GetEmployeeByIdAsync(int id);
        Task<Employee> CreateEmployeeAsync(AddEmployeeModel model);
        Task<Employee> UpdateEmployeeAsync(AddEmployeeModel model);
    }
}
