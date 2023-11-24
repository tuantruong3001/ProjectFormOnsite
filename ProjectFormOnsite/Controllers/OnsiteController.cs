using Microsoft.AspNetCore.Http;
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
                return Ok(await _onsiteRepo.GetAllOnsiteAsync());
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
    }
}
