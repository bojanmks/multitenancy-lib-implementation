using MultiTenancy.Application.DTO;

namespace MultiTenancy.Api.DTO
{
    public class ImageDtoApi : ImageDto
    {
        public IFormFile ImageFile { get; set; }
    }
}
