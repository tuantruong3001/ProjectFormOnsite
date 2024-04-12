using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Models;
using App.Domain.Interfaces.IServices;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnsiteController : ControllerBase
    {
        private readonly IOnsiteService _onsiteService;
        public OnsiteController(IOnsiteService onsiteService)
        {
            _onsiteService = onsiteService;
        }

        [HttpGet("GetAllOnsite")]
        public async Task<IActionResult> GetAllOnsite()
        {
            try
            {
                var onsite = await _onsiteService.GetAllOnsiteAsync();
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
                var newOnsiteId = await _onsiteService.CreateOnsiteAsync(model);
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
                await _onsiteService.UpdateOnsiteAsync(model);
                return Ok();
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
                await _onsiteService.DeleteAsync(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPatch("ConfirmOnsiteAsync/{id}")]
        public async Task<IActionResult> ConfirmOnsiteAsync(int id, ConfirmModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("NotFound");
                }
                var newOnsiteId = await _onsiteService.ConfirmOnsiteAsync(id, model);

                return newOnsiteId == null ? NotFound() : Ok(newOnsiteId);
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
