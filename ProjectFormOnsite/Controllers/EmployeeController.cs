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
        [HttpGet]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                return Ok(await _employeeRepo.GetAllEmployeeAsync());
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
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, [FromBody] EmployeeModel model)
        {
            try
            {
                if (id != model.EmployeeID)
                {
                    return NotFound();
                }
                await _employeeRepo.UpdateEmployeeAsync(id, model);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            try
            {
                await _employeeRepo.DeleteEmployeeAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
