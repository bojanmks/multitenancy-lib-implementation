using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Application.DTO;
using MultiTenancy.Application.Search.SearchObjects;
using MultiTenancy.Application.UseCases.Specifications;
using MultiTenancy.Domain;
using MultiTenancy.Implementation.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenancy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecificationsController : ControllerBase
    {
        private readonly UseCaseMediator _mediator;
        public SpecificationsController(UseCaseMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] SpecificationSearch search)
        {
            return Ok(_mediator.Search<SearchSpecificationsUseCase, SpecificationSearch, SpecificationDto, Specification>(new SearchSpecificationsUseCase(search)));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mediator.Find<FindSpecificationUseCase, SpecificationDto, Specification>(new FindSpecificationUseCase(id)));
        }

        [HttpPost]
        public void Post([FromBody] SpecificationDto dto)
        {
            _mediator.Insert<AddSpecificationUseCase, SpecificationDto, Specification>(new AddSpecificationUseCase(dto));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] SpecificationDto dto)
        {
            dto.Id = id;
            _mediator.Update<EditSpecificationUseCase, SpecificationDto, Specification>(new EditSpecificationUseCase(dto));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _mediator.Delete<DeleteSpecificationUseCase, Specification>(new DeleteSpecificationUseCase(id));
        }
    }
}
