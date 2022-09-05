using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Application.DTO;
using MultiTenancy.Application.Search.SearchObjects;
using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Cart;
using MultiTenancy.Application.UseCases.Products;
using MultiTenancy.Domain;
using MultiTenancy.Implementation.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenancy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly UseCaseMediator _mediator;
        public CartController(UseCaseMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] CartSearch search)
        {
            return Ok(_mediator.Search<SearchCartUseCase, CartSearch, CartItemDto, CartItem>(new SearchCartUseCase(search)));
        }

        [HttpPost]
        public void Post([FromBody] CartItemDto dto)
        {
            _mediator.Execute<AddCartItemUseCase, CartItemDto, Empty>(new AddCartItemUseCase(dto));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CartItemDto dto)
        {
            dto.Id = id;
            _mediator.Execute<EditCartItemUseCase, CartItemDto, Empty>(new EditCartItemUseCase(dto));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _mediator.Delete<DeleteCartItemUseCase, CartItem>(new DeleteCartItemUseCase(id));
        }
    }
}
