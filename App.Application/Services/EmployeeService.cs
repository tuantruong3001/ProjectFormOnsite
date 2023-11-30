using App.DAL.Data;
using App.Domain.Entities;
using App.Domain.Interfaces.IServices;
using App.Domain.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Services
{

    public class EmployeeService : BaseService<Employee, int>, IEmployeeService
    {
        public EmployeeService(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {

        }

        public async Task<List<EmployeeModel>> GetAllEmployeeAsync()
        {
            var employee = await _dataContext.Employees
                .Include(a => a.Department)
                .ToListAsync();

            return _mapper.Map<List<EmployeeModel>>(employee);
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            var employee = await _dataContext.Employees
                .Include(a => a.Department)
                .FirstOrDefaultAsync(o => o.EmployeeID == id);

            return _mapper.Map<EmployeeModel>(employee);
        }
    }
}
