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
