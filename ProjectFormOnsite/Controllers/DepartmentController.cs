using Microsoft.AspNetCore.Mvc;
using App.Domain.Models;
using App.Domain.Interfaces.IRepositories;
using App.Domain.Entities;
using AutoMapper;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRepo _departmentRepo;
        private readonly IMapper _mapper;

        public DepartmentController(IDepartmentRepo repo, IMapper mapper)
        {
            _departmentRepo = repo;
            _mapper = mapper;
        }

        [HttpGet("GetAllDepartment")]
        public async Task<IActionResult> GetAllDepartment()
        {
            try
            {
                var department = await _departmentRepo.GetAllAsync();
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
                var department = await _departmentRepo.GetByIdAsync(id);
                return department == null ? NotFound() : Ok(department);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment(DepartmentModel model)
        {
            try
            {
                var departmentEntity = _mapper.Map<Department>(model);
                var newDepartmentId = await _departmentRepo.CreateAsync(departmentEntity);
                return Ok(newDepartmentId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateDepartment")]
        public async Task<IActionResult> UpdateDepartment([FromBody] DepartmentModel model)
        {
            try
            {               
                var departmentEntity = _mapper.Map<Department>(model);
                var updateDepartment = await _departmentRepo.UpdateAsync(departmentEntity);
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
                await _departmentRepo.DeleteAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
