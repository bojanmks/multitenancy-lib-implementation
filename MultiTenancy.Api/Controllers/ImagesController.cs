using Microsoft.AspNetCore.Mvc;
using MultiTenancy.Api.Core.FileStorage;
using MultiTenancy.Api.DTO;
using MultiTenancy.Application.DTO;
using MultiTenancy.Application.Exceptions;
using MultiTenancy.Application.UseCases.Images;
using MultiTenancy.Domain;
using MultiTenancy.Implementation.UseCases;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MultiTenancy.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromForm] ImageDtoApi dto, [FromServices] UseCaseMediator mediator)
        {
            if (dto.ImageFile != null)
            {
                dto.Path = FileStorage.UploadFile(dto.ImageFile, "Images", new List<string> { ".jpg", ".jpeg", ".png", ".webp" });
            }
            else
            {
                throw new UnprocessableEntityException("Image wasn't provided.");
            }

            return Ok(mediator.Execute<AddImageUseCase, ImageDto, ImageDto>(new AddImageUseCase(dto)));
        }
    }
}
