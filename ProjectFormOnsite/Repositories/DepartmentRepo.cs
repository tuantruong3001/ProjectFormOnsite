using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectFormOnsite.Data;
using ProjectFormOnsite.Models;

namespace ProjectFormOnsite.Repositories
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

        public Task DeleteDepartmentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<DepartmentModel>> GetAllDepartmentAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<DepartmentModel> GetDepartmentByIdAsync(int id)
        {
            var department = await _context.Departments.FindAsync(id);
            return _mapper.Map<DepartmentModel>(department);
        }

        public Task UpdateDepartmentAsync(int id, DepartmentModel model)
        {
            throw new NotImplementedException();
        }
    }
}
