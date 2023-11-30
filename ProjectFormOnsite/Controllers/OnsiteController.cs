using Microsoft.AspNetCore.JsonPatch;
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
    public class OnsiteController : ControllerBase
    {
        private readonly IOnsiteRepo _onsiteRepo;
        private readonly IMapper _mapper;
        private readonly IOnsiteService _onsiteService;
        public OnsiteController(IOnsiteRepo repo,IMapper mapper, IOnsiteService onsiteService)
        {
            _onsiteRepo = repo;
            _mapper = mapper;
            _onsiteService = onsiteService;
        }

        [HttpGet("GetAllOnsite")]
        public async Task<IActionResult> GetAllOnsite()
        {
            try
            {
                var onsite = await _onsiteRepo.GetAllOnsiteAsync();
                return Ok(onsite);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("GetOnsiteById/{id}")]
        public async Task<IActionResult> GetOnsiteById(int id)
        {
            try
            {
                var onsite = await _onsiteService.GetOnsiteByIdAsync(id);
                return onsite == null ? NotFound() : Ok(onsite);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("CreateOnsite")]
        public async Task<IActionResult> CreateOnsite(OnsiteModel model)
        {
            try
            {
                var onsiteEntity = _mapper.Map<Onsite>(model);
                var newOnsiteId = await _onsiteRepo.CreateAsync(onsiteEntity);
                return newOnsiteId == null ? NotFound() : Ok(newOnsiteId);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateOnsite")]
        public async Task<IActionResult> UpdateOnsite([FromBody] OnsiteModel model)
        {
            try
            {
                var onsiteEntity = _mapper.Map<Onsite>(model);
                await _onsiteRepo.UpdateAsync(onsiteEntity);
                return Ok(onsiteEntity);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteOnsite/{id}")]
        public async Task<IActionResult> DeleteOnsite([FromRoute] int id)
        {
            try
            {
                await _onsiteRepo.DeleteAsync(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPatch("ConfirmOnsiteAsync")]
        public async Task<IActionResult> ConfirmOnsiteAsync(int id,[FromBody] JsonPatchDocument<ConfirmModel> patchDoc)
        {
            try
            {
                if (patchDoc == null || !ModelState.IsValid)
                {
                    return BadRequest("Invalid patch document");
                }
                await _onsiteService.ConfirmOnsiteAsync(id, patchDoc);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("RegisterOnsite")]
        public async Task<IActionResult> RegisterOnsite(RegisterOnsiteModel model)
        {
            try
            {
                if (model == null)
                {
                    return BadRequest();
                }
                var newOnsiteId = await _onsiteService.RegisterOnsiteAsync(model);

                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
