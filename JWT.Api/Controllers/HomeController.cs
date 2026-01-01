using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWT.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        public HomeController() { }

        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var numbers = new List<int>
            {
                1,
                2,
                3
            };
            return Ok(numbers);
        }
    }
}
