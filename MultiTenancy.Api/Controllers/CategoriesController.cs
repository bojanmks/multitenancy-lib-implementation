using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Application.DTO;
using MultiTenancy.Application.Search.SearchObjects;
using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Categories;
using MultiTenancy.Application.UseCases.Category;
using MultiTenancy.Domain;
using MultiTenancy.Implementation.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenancy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly UseCaseMediator _mediator;
        public CategoriesController(UseCaseMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] CategorySearch search)
        {
            return Ok(_mediator.Search<SearchCategoriesUseCase, CategorySearch, CategoryDto, Category>(new SearchCategoriesUseCase(search)));
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_mediator.Find<FindCategoryUseCase, CategoryDto, Category>(new FindCategoryUseCase(id)));
        }

        [HttpPost]
        public void Post([FromBody] CategoryDto dto)
        {
            _mediator.Execute<AddCategoryUseCase, CategoryDto, Empty>(new AddCategoryUseCase(dto));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CategoryDto dto)
        {
            dto.Id = id;
            _mediator.Execute<EditCategoryUseCase, CategoryDto, Empty>(new EditCategoryUseCase(dto));
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _mediator.Execute<DeleteCategoryUseCase, int, Empty>(new DeleteCategoryUseCase(id));
        }
    }
}
