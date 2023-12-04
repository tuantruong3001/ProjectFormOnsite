using App.DAL.Data;
using App.Domain.Entities;
using App.Domain.Interfaces.IRepositories;
using App.Domain.Interfaces.IServices;
using App.Domain.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace App.Application.Services
{

    public class EmployeeService : BaseService<Employee, int>, IEmployeeService
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeService(DataContext dataContext, IMapper mapper, IEmployeeRepo employeeRepo) : base(dataContext, mapper, employeeRepo)
        {
            _employeeRepo = employeeRepo;
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
        public async Task<Employee> CreateEmployeeAsync(AddEmployeeModel model)
        {
            var employeeEntity = _mapper.Map<Employee>(model);
            return await _employeeRepo.CreateAsync(employeeEntity);
        }

        public async Task<Employee> UpdateEmployeeAsync(AddEmployeeModel model)
        {
            var employeeEntity = _mapper.Map<Employee>(model);
            return await _employeeRepo.UpdateAsync(employeeEntity);
        }
    }
}
