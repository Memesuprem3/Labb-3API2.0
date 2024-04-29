using Labb_3API2._0.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_3API2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController : ControllerBase
    {
        private ILink _linkRepo;

        public LinkController(ILink linkRepo)
        {
            _linkRepo = linkRepo;
        }

        [HttpGet("Links")]
        public async Task<IActionResult> GetAllLinks()
        {
            try
            {
                return Ok(await _linkRepo.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }
    }
}
