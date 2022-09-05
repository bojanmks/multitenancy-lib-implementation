using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Application.DTO;
using MultiTenancy.Application.Search.SearchObjects;
using MultiTenancy.Application.UseCases.Countries;
using MultiTenancy.Domain;
using MultiTenancy.Implementation.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenancy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly UseCaseMediator _mediator;
        public CountriesController(UseCaseMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] CountrySearch search)
        {
            return Ok(_mediator.Search<SearchCountriesUseCase, CountrySearch, CountryDto, Country>(new SearchCountriesUseCase(search)));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mediator.Find<FindCountryUseCase, CountryDto, Country>(new FindCountryUseCase(id)));
        }

        [HttpPost]
        public void Post([FromBody] CountryDto dto)
        {
            _mediator.Insert<AddCountryUseCase, CountryDto, Country>(new AddCountryUseCase(dto));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CountryDto dto)
        {
            dto.Id = id;
            _mediator.Update<EditCountryUseCase, CountryDto, Country>(new EditCountryUseCase(dto));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _mediator.Delete<DeleteCountryUseCase, Country>(new DeleteCountryUseCase(id));
        }
    }
}
