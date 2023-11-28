using App.Domain.Models;

namespace App.Domain.Interfaces.IRepositories
{
    public interface IDepartmentRepo
    {
        public Task<List<DepartmentModel>> GetAllDepartmentAsync();
        public Task<DepartmentModel> GetDepartmentByIdAsync(int id);
        public Task<int> CreateDepartmentAsync(DepartmentModel model);
        public Task UpdateDepartmentAsync(int id, DepartmentModel model);
        public Task DeleteDepartmentAsync(int id);
    }
}
