using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> GetOnsite()
        {
            try
            { 
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
