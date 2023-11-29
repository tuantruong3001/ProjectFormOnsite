using Microsoft.AspNetCore.Mvc;
using App.Domain.Models;
using App.Domain.Interfaces.IRepositories;

namespace App.API.Controllers
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

        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var employee = await _employeeRepo.GetAllEmployeeAsync();
                return Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetEmployeeById/{id}")]
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

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> AddEmployee(AddEmployeeModel model)
        {
            try
            {
                var newEmployeeId = await _employeeRepo.CreateEmployeeAsync(model);
                var employee = await _employeeRepo.GetEmployeeByIdAsync(newEmployeeId);
                return employee == null ? NotFound() : Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateEmployee/{id}")]
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

        [HttpDelete("DeleteEmployee/{id}")]
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
