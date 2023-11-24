using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectFormOnsite.Models;
using ProjectFormOnsite.Repositories;

namespace ProjectFormOnsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;
        public EmployeeController(IEmployeeRepo repo)
        {
            _employeeRepo = repo;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            try
            {
                var employee = await _employeeRepo.GetEmployeeByIdAsync(id);
                return employee == null ? NotFound() : Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeModel model)
        {
            try
            {
                var newEmployeeId = await _employeeRepo.AddEmployeeAsync(model);
                var employee = await _employeeRepo.GetEmployeeByIdAsync(newEmployeeId);
                return employee == null ? NotFound() : Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
