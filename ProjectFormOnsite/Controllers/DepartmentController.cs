using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectFormOnsite.Models;
using ProjectFormOnsite.Repositories;

namespace ProjectFormOnsite.Controllers
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
        [HttpGet("{id}")]
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
        [HttpPost]
        public async Task<IActionResult> AddDepartment(DepartmentModel model)
        {
            try
            {
                var newDepartmentId = await _departmentRepo.AddDepartmentAsync(model);
                var department = await _departmentRepo.GetDepartmentByIdAsync(newDepartmentId);
                return department == null ? NotFound() : Ok(department);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpGet]
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
        [HttpPut("{id}")]
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
        [HttpDelete("{id}")]
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
