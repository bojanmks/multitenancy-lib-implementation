using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Application.DTO;
using MultiTenancy.Application.Search.SearchObjects;
using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Orders;
using MultiTenancy.DataAccess;
using MultiTenancy.Domain;
using MultiTenancy.Implementation.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenancy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly UseCaseMediator _mediator;
        public OrdersController(UseCaseMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public IActionResult Get([FromQuery] OrderSearch search)
        {
            return Ok(_mediator.Search<SearchOrdersUseCase, OrderSearch, OrderDto, Order>(new SearchOrdersUseCase(search)));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mediator.Find<FindOrderUseCase, OrderDto, Order>(new FindOrderUseCase(id)));
            
        }

        [HttpPost]
        public void Post([FromBody] AddOrderDto dto)
        {
            _mediator.Insert<AddOrderUseCase, AddOrderDto, Order>(new AddOrderUseCase(dto));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EditOrderDto dto)
        {
            dto.Id = id;
            _mediator.Execute<EditOrderUseCase, EditOrderDto, Empty>(new EditOrderUseCase(dto));
        }

    }
}
