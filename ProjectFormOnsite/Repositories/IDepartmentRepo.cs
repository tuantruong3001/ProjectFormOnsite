using App.API.Models;

namespace App.API.Repositories
{
    public interface IDepartmentRepo
    {
        public Task<List<DepartmentModel>> GetAllDepartmentAsync();
        public Task<DepartmentModel> GetDepartmentByIdAsync(int id);
        public Task<int> AddDepartmentAsync(DepartmentModel model);
        public Task UpdateDepartmentAsync(int id, DepartmentModel model);
        public Task DeleteDepartmentAsync(int id);
    }
}
