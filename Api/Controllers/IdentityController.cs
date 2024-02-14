using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class IdentityController : ControllerBase
    {



        [HttpGet]
        public IActionResult GetClaims()
        {
            return Ok(User.Claims.Select(s => new { s.Type, s.Value }).ToList());
        }




    }
}
