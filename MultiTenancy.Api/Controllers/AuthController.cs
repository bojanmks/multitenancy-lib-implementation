using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Api.Core.Jwt;
using MultiTenancy.Api.DTO;
using MultiTenency.Core;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenancy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] LoginRequestDto dto, [FromServices] JwtManager manager)
        {
            var token = manager.MakeToken(dto.Email, dto.Password);

            return Ok(new { token });
        }
    }
}
