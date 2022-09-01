using MultiTenancy.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Images
{
    public class AddImageUseCase : UseCase<ImageDto>
    {
        public AddImageUseCase(ImageDto data) : base(data)
        {
        }

        public override string Id => "AddImageUseCase";
    }
}
