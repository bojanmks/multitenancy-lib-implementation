using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Application.DTO;
using MultiTenancy.Application.Search.SearchObjects;
using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Addresses;
using MultiTenancy.Domain;
using MultiTenancy.Implementation.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenancy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly UseCaseMediator _mediator;
        public AddressesController(UseCaseMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] AddressSearch search)
        {
            return Ok(_mediator.Search<SearchAddressesUseCase, AddressSearch, AddressDto, Address>(new SearchAddressesUseCase(search)));
        }

        [HttpPost]
        public void Post([FromBody] AddressDto dto)
        {
            _mediator.Insert<AddAddressUseCase, AddressDto, Address>(new AddAddressUseCase(dto));
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _mediator.Delete<DeleteAddressUseCase, Address>(new DeleteAddressUseCase(id));
        }
    }
}
