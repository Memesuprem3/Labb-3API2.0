using Labb_3API2._0.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Labb_3API2._0.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : ControllerBase
    {
        private IInterest _interestRepository;

        public InterestController(IInterest interest)
        {
            _interestRepository = interest;
        }

        [HttpGet("Interests")]
        public async Task<IActionResult> GetAllInterests()
        {
            try
            {
                return Ok(await _interestRepository.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error to get data from database");
            }
        }
    }
}
