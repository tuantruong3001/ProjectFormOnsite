using AutoMapper;
using Microsoft.EntityFrameworkCore;
using App.Domain.Entities;
using App.Domain.Models;
using App.DAL.Data;
using App.Domain.Interfaces.IRepositories;

namespace App.DAL.Repositories
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public DepartmentRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddDepartmentAsync(DepartmentModel model)
        {
            var newOnsite = _mapper.Map<Department>(model);
            _context.Departments!.Add(newOnsite);
            await _context.SaveChangesAsync();

            return newOnsite.DepartmentID;
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            var deleteDepartment = _context.Departments!.FirstOrDefault(a => a.DepartmentID == id);
            if (deleteDepartment != null)
            {
                _context.Departments.Remove(deleteDepartment);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DepartmentModel>> GetAllDepartmentAsync()
        {
            var department = await _context.Departments!.ToListAsync();
            return _mapper.Map<List<DepartmentModel>>(department);
        }

        public async Task<DepartmentModel> GetDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            return _mapper.Map<DepartmentModel>(department);
        }

        public async Task UpdateDepartmentAsync(int id, DepartmentModel model)
        {
            if (id == model.DepartmentID)
            {
                var updateDepartment = _mapper.Map<Department>(model);
                _context.Departments.Update(updateDepartment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
