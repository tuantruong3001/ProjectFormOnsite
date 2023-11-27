﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectFormOnsite.Models;
using ProjectFormOnsite.Repositories;

namespace ProjectFormOnsite.Controllers
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

        [HttpGet]
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
        [HttpGet("{id}")]
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
        [HttpPost]
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
        [HttpPut]
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
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOnsite([FromRoute] int id)
        {
            try
            {               
                await _onsiteRepo.DeleteOnsiteAsync(id);
                return Ok();
            }
            catch { 
                return NotFound();
            }           
        }
        [HttpPatch]
        public async Task<IActionResult> ConfirmOnsite(int id, [FromBody] ConfirmModel model)
        {
            try
            {
                if (id != model.OnsiteID)
                {
                    return NotFound();
                }
                await _onsiteRepo.ConfirmOnsiteAsync(id, model);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
