using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Application.DTO;
using MultiTenancy.Application.UseCases.Users;
using MultiTenancy.Domain;
using MultiTenancy.Implementation.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenancy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        [HttpPost]
        public void Post([FromBody] RegisterDto dto, [FromServices] UseCaseMediator mediator)
        {
            mediator.Insert<RegisterUseCase, RegisterDto, User>(new RegisterUseCase(dto));
        }
    }
}
