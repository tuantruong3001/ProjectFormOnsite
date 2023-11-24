using AutoMapper;
using ProjectFormOnsite.Data;
using ProjectFormOnsite.Models;

namespace ProjectFormOnsite.Repositories
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
        public async Task<int> AddEmployeeAsync(EmployeeModel model)
        {
            var newOnsite = _mapper.Map<Employee>(model);
            _context.Employees!.Add(newOnsite);
            await _context.SaveChangesAsync();

            return newOnsite.EmployeeID;
        }

        public Task DeleteEmployeeAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<EmployeeModel>> GetAllEmployeeAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<EmployeeModel> GetEmployeeByIdAsync(int id)
        {
            var employee = await _context.Employees.FindAsync(id);
            return _mapper.Map<EmployeeModel>(employee);
        }

        public Task UpdateEmployeeAsync(int id, EmployeeModel model)
        {
            throw new NotImplementedException();
        }
    }
}
