using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Application.DTO;
using MultiTenancy.Application.Search.SearchObjects;
using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Products;
using MultiTenancy.Domain;
using MultiTenancy.Implementation.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenancy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly UseCaseMediator _mediator;
        public ProductsController(UseCaseMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] ProductSearch search)
        {
            return Ok(_mediator.Search<SearchProductsUseCase, ProductSearch, ProductDto, Product>(new SearchProductsUseCase(search)));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mediator.Find<FindProductUseCase, ProductDto, Product>(new FindProductUseCase(id)));
        }

        [HttpPost]
        public void Post([FromBody] ProductDto dto)
        {
            _mediator.Execute<AddProductUseCase, ProductDto, Empty>(new AddProductUseCase(dto));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ProductDto dto)
        {
            dto.Id = id;
            _mediator.Execute<EditProductUseCase, ProductDto, Empty>(new EditProductUseCase(dto));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _mediator.Execute<DeleteProductUseCase, int, Empty>(new DeleteProductUseCase(id));
        }
    }
}
