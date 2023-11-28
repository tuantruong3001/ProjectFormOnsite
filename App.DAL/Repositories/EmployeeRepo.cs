using AutoMapper;
using Microsoft.EntityFrameworkCore;
using App.Domain.Entities;
using App.Domain.Models;
using App.DAL.Data;
using App.Domain.Interfaces.IRepositories;

namespace App.DAL.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public EmployeeRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddEmployeeAsync(AddEmployeeModel model)
        {
            var newOnsite = _mapper.Map<Employee>(model);
            _context.Employees!.Add(newOnsite);
            await _context.SaveChangesAsync();

            return newOnsite.EmployeeID;
        }
        public async Task DeleteEmployeeAsync(int id)
        {
            var deleteEmployee = _context.Employees!.FirstOrDefault(a => a.EmployeeID == id);
            if (deleteEmployee != null)
            {
                _context.Employees.Remove(deleteEmployee);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<EmployeeModel>> GetAllEmployeeAsync()
        {
            var employee = await _context.Employees
                .Include(a => a.Department)
                .ToListAsync();

            return _mapper.Map<List<EmployeeModel>>(employee);
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees
                .Include(a => a.Department)
                .FirstOrDefaultAsync(o => o.EmployeeID == id);   
            
            return _mapper.Map<EmployeeModel>(employee);
        }

        public async Task UpdateEmployeeAsync(int id, EmployeeModel model)
        {
            if (id == model.EmployeeID)
            {
                var updateEmployee = _mapper.Map<Employee>(model);
                _context.Employees!.Update(updateEmployee);
                await _context.SaveChangesAsync();
            }
        }
    }
}
