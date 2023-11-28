using AutoMapper;
using Microsoft.EntityFrameworkCore;
using App.Domain.Entities;
using App.Domain.Models;
using App.DAL.Data;
using App.Domain.Interfaces.IRepositories;

namespace App.DAL.Repositories
{
    public class DepartmentRepo : BaseRepository<Department, int>, IDepartmentRepo

    {
        public DepartmentRepo(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {

        }
        public async Task<int> CreateDepartmentAsync(DepartmentModel model)
        {
            var newOnsite = _mapper.Map<Department>(model);
            _dataContext.Departments!.Add(newOnsite);
            await _dataContext.SaveChangesAsync();

            return newOnsite.DepartmentID;
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var deleteDepartment = _dataContext.Departments!.FirstOrDefault(a => a.DepartmentID == id);
            if (deleteDepartment != null)
            {
                _dataContext.Departments.Remove(deleteDepartment);
                await _dataContext.SaveChangesAsync();
            }
        }

        public async Task<List<DepartmentModel>> GetAllDepartmentAsync()
        {
            var department = await _dataContext.Departments!.ToListAsync();
            return _mapper.Map<List<DepartmentModel>>(department);
        }

        public async Task<DepartmentModel> GetDepartmentByIdAsync(int id)
        {
            var department = await _dataContext.Departments.FindAsync(id);
            return _mapper.Map<DepartmentModel>(department);
        }

        public async Task UpdateDepartmentAsync(int id, DepartmentModel model)
        {
            if (id == model.DepartmentID)
            {
                var updateDepartment = _mapper.Map<Department>(model);
                _dataContext.Departments.Update(updateDepartment);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
