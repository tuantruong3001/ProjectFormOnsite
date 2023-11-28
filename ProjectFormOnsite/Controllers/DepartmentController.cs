using Microsoft.AspNetCore.Mvc;
using App.Domain.Models;
using App.Domain.Interfaces.IRepositories;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo _departmentRepo;
        public DepartmentController(IDepartmentRepo repo)
        {
            _departmentRepo = repo;
        }

        [HttpGet("GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            try
            {
                var department = await _departmentRepo.GetAllDepartmentAsync();
                return Ok(department);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetDepartmentById/{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            try
            {
                var department = await _departmentRepo.GetDepartmentByIdAsync(id);
                return department == null ? NotFound() : Ok(department);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> AddDepartment(DepartmentModel model)
        {
            try
            {
                var newDepartmentId = await _departmentRepo.CreateDepartmentAsync(model);
                var department = await _departmentRepo.GetDepartmentByIdAsync(newDepartmentId);
                return department == null ? NotFound() : Ok(department);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        
        [HttpPut("UpdateDepartment/{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentModel model)
        {
            try
            {
                if (id != model.DepartmentID)
                {
                    return NotFound();
                }
                await _departmentRepo.UpdateDepartmentAsync(id, model);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpDelete("DeleteDepartment/{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                await _departmentRepo.DeleteDepartmentAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
