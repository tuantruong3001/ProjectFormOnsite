using App.Domain.Models;

namespace App.Domain.Interfaces.IRepositories
{
    public interface IEmployeeRepo
    {
        public Task<List<EmployeeModel>> GetAllEmployeeAsync();
        public Task<EmployeeModel> GetEmployeeByIdAsync(int id);
        public Task<int> CreateEmployeeAsync(AddEmployeeModel model);
        public Task UpdateEmployeeAsync(int id, EmployeeModel model);
        public Task DeleteEmployeeAsync(int id);
    }
}
