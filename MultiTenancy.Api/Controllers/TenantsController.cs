using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Application.DTO;
using MultiTenancy.Application.Search.SearchObjects;
using MultiTenancy.Application.UseCases.Tenants;
using MultiTenancy.Domain;
using MultiTenancy.Implementation.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenancy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly UseCaseMediator _mediator;
        public TenantsController(UseCaseMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] TenantSearch search)
        {
            return Ok(_mediator.Search<SearchTenantsUseCase, TenantSearch, TenantDto, Tenant>(new SearchTenantsUseCase(search)));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mediator.Find<FindTenantUseCase, TenantDto, Tenant>(new FindTenantUseCase(id)));
        }

        [HttpPost]
        public void Post([FromBody] TenantDto dto)
        {
            _mediator.Insert<AddTenantUseCase, TenantDto, Tenant>(new AddTenantUseCase(dto));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] TenantDto dto)
        {
            dto.Id = id;
            _mediator.Update<EditTenantUseCase, TenantDto, Tenant>(new EditTenantUseCase(dto));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _mediator.Delete<DeleteTenantUseCase, Tenant>(new DeleteTenantUseCase(id));
        }
    }
}
