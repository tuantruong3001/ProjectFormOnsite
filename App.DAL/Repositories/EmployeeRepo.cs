using AutoMapper;
using Microsoft.EntityFrameworkCore;
using App.Domain.Entities;
using App.Domain.Models;
using App.DAL.Data;
using App.Domain.Interfaces.IRepositories;

namespace App.DAL.Repositories
{
    public class EmployeeRepo : BaseRepository<Employee, int>, IEmployeeRepo
    {
        public EmployeeRepo(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {

        }
        public async Task<int> CreateEmployeeAsync(AddEmployeeModel model)
        {
            var employeeEntity = _mapper.Map<Employee>(model);
            var createdEmployee = await CreateAsync(employeeEntity);
            return createdEmployee.EmployeeID;
        }
        public async Task DeleteEmployeeAsync(int id)
        {
            var deleteEmployee = _dataContext.Employees!.FirstOrDefault(a => a.EmployeeID == id);
            if (deleteEmployee != null)
            {
                _dataContext.Employees.Remove(deleteEmployee);
                await _dataContext.SaveChangesAsync();
            }
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

        public async Task UpdateEmployeeAsync(int id, EmployeeModel model)
        {
            if (id == model.EmployeeID)
            {
                var updateEmployee = _mapper.Map<Employee>(model);
                _dataContext.Employees!.Update(updateEmployee);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
