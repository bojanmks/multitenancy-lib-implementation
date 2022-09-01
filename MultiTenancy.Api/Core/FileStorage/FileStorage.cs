using MultiTenancy.Application.Exceptions;

namespace MultiTenancy.Api.Core.FileStorage
{
    public static class FileStorage
    {
        public static string UploadFile(IFormFile file, string folder, IEnumerable<string> supportedExtensions)
        {
            var extension = Path.GetExtension(file.FileName);

            if (!supportedExtensions.Contains(extension))
            {
                throw new UnprocessableEntityException("Unsupported file type.");
            }

            var guid = Guid.NewGuid();

            var fileName = guid + extension;

            var path = Path.Combine("wwwroot", folder, fileName);

            using (Stream fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            return fileName;
        }
    }
}
