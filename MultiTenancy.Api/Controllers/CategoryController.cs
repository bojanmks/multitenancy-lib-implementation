using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Application.DTO;
using MultiTenancy.Application.UseCases.Category;
using MultiTenancy.Domain;
using MultiTenancy.Implementation.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenancy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly UseCaseMediator _mediator;
        public CategoryController(UseCaseMediator mediator)
        {
            _mediator = mediator;
        }

        //// GET: api/<CategoryController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<CategoryController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}


        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] CategoryDto dto)
        {
            _mediator.Insert<AddCategoryUseCase, CategoryDto, Category>(new AddCategoryUseCase(dto));

        }


        //// PUT api/<CategoryController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CategoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
