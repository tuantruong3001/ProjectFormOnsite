using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using App.Domain.Models;
using App.Domain.Interfaces.IRepositories;

namespace App.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnsiteController : ControllerBase
    {
        private readonly IOnsiteRepo _onsiteRepo;
        public OnsiteController(IOnsiteRepo repo)
        {
            _onsiteRepo = repo;
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

        [HttpGet("GetOnsiteById{id}")]
        public async Task<IActionResult> GetOnsiteById(int id)
        {
            try
            {
                var onsite = await _onsiteRepo.GetOnsiteByIdAsync(id);
                return onsite == null ? NotFound() : Ok(onsite);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("AddOnsite")]
        public async Task<IActionResult> AddOnsite(OnsiteModel model)
        {
            try
            {
                var newOnsiteId = await _onsiteRepo.AddOnsiteAsync(model);
                var onsite = await _onsiteRepo.GetOnsiteByIdAsync(newOnsiteId);
                return onsite == null ? NotFound() : Ok(onsite);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("UpdateOnsite")]
        public async Task<IActionResult> UpdateOnsite(int id, [FromBody] OnsiteModel model)
        {
            try
            {
                if (id != model.OnsiteID)
                {
                    return NotFound();
                }
                await _onsiteRepo.UpdateOnsiteAsync(id, model);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpDelete("DeleteOnsite{id}")]
        public async Task<IActionResult> DeleteOnsite([FromRoute] int id)
        {
            try
            {
                await _onsiteRepo.DeleteOnsiteAsync(id);
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPatch("ConfirmOnsiteAsync{id}")]
        public async Task<IActionResult> ConfirmOnsiteAsync(int id, [FromBody] JsonPatchDocument<ConfirmModel> patchDoc)
        {
            try
            {
                await _onsiteRepo.ConfirmOnsiteAsync(id, patchDoc);
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
                var newOnsiteId = await _onsiteRepo.RegisterOnsiteAsync(model);

                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
