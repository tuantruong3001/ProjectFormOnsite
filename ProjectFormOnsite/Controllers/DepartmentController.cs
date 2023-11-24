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
                return department == null? NotFound() : Ok(department);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
