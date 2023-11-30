using Microsoft.AspNetCore.Mvc;
using App.Domain.Models;
using App.Domain.Interfaces.IRepositories;
using AutoMapper;
using App.Domain.Entities;
using App.Domain.Interfaces.IServices;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo _employeeRepo;
        private readonly IMapper _mapper;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeRepo repo, IMapper mapper, IEmployeeService employeeService)
        {
            _employeeRepo = repo;
            _mapper = mapper;
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployee()
        {
            try
            {
                var employee = await _employeeService.GetAllEmployeeAsync();
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
                var employee = await _employeeService.GetEmployeeByIdAsync(id);
                return employee == null ? NotFound() : Ok(employee);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateEmployee")]
        public async Task<IActionResult> CreateEmployee(AddEmployeeModel model)
        {
            try
            {
                var employeeEntity = _mapper.Map<Employee>(model);
                var newEmployeeId = await _employeeRepo.CreateAsync(employeeEntity);
                return employeeEntity == null ? NotFound() : Ok(employeeEntity);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateEmployee")]
        public async Task<IActionResult> UpdateEmployee([FromBody] AddEmployeeModel model)
        {
            try
            {
                var employeeEntity = _mapper.Map<Employee>(model);
                await _employeeRepo.UpdateAsync(employeeEntity);
                return Ok(employeeEntity);
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
                await _employeeRepo.DeleteAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
