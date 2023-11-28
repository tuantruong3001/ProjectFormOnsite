using App.API.Models;

namespace App.API.Repositories
{
    public interface IEmployeeRepo
    {
        public Task<List<EmployeeModel>> GetAllEmployeeAsync();
        public Task<EmployeeModel> GetEmployeeByIdAsync(int id);
        public Task<int> AddEmployeeAsync(AddEmployeeModel model);
        public Task UpdateEmployeeAsync(int id, EmployeeModel model);
        public Task DeleteEmployeeAsync(int id);
    }
}
