using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Application.DTO;
using MultiTenancy.Application.Search.SearchObjects;
using MultiTenancy.Application.UseCases.Users;
using MultiTenancy.Domain;
using MultiTenancy.Implementation.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenancy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UseCaseMediator _mediator;
        public UsersController(UseCaseMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch search)
        {
            return Ok(_mediator.Search<SearchUsersUseCase, UserSearch, UserDto, User>(new SearchUsersUseCase(search)));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mediator.Find<FindUserUseCase, UserDto, User>(new FindUserUseCase(id)));
        }

        [HttpPost]
        public void Post([FromBody] UserDto dto)
        {
            _mediator.Insert<AddUserUseCase, UserDto, User>(new AddUserUseCase(dto));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserDto dto)
        {
            dto.Id = id;
            _mediator.Update<EditUserUseCase, UserDto, User>(new EditUserUseCase(dto));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _mediator.Delete<DeleteUserUseCase, User>(new DeleteUserUseCase(id));
        }
    }
}
