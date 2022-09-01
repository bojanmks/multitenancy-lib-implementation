using AutoMapper;
using MultiTenancy.Application.DTO;
using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Images;
using MultiTenancy.DataAccess;
using MultiTenancy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.UseCases.Handlers.Images
{
    public class AddImageUseCaseHandler : EfUseCaseHandler<AddImageUseCase, ImageDto>
    {
        private readonly IMapper _mapper;
        public AddImageUseCaseHandler(ShopDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public override ImageDto Handle(AddImageUseCase useCase)
        {
            var data = useCase.Data;

            var image = _mapper.Map<Image>(data);

            _context.Images.Add(image);

            _context.SaveChanges();

            return _mapper.Map<ImageDto>(image);
        }
    }
}
