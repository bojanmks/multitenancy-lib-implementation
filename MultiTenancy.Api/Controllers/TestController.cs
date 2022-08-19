using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Application.DTO;
using MultiTenancy.Application.Search;
using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Test;
using MultiTenancy.DataAccess;
using MultiTenancy.Domain;
using MultiTenancy.Implementation.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenancy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly UseCaseMediator _mediator;
        public TestController(UseCaseMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public IActionResult Get([FromQuery] TestSearch search)
        {
            return Ok(_mediator.Search<SearchTestUseCase, TestSearch, TestDto, Test>(new SearchTestUseCase(search)));
        }

        [HttpGet("{id}")]
        public IActionResult Find(int id)
        {
            return Ok(_mediator.Find<FindTestUseCase, TestDto, Test>(new FindTestUseCase(id)));
        }

        [HttpPost]
        public void Add([FromBody] TestDto dto)
        {
            _mediator.Insert<AddTestUseCase, TestDto, Test>(new AddTestUseCase(dto));
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] TestDto dto)
        {
            dto.Id = id;
            _mediator.Update<UpdateTestUseCase, TestDto, Test>(new UpdateTestUseCase(dto));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _mediator.Delete<DeleteTestUseCase, Test>(new DeleteTestUseCase(id));
        }

        [HttpPost("test/{id}")]
        public void Test(int id)
        {
            _mediator.Execute<ExecuteTestUseCase, int, Empty>(new ExecuteTestUseCase(id));
        }
    }
}
