using AutoMapper;
using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Products;
using MultiTenancy.DataAccess;
using MultiTenancy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.UseCases.Handlers.Products
{
    public class EditProductUseCaseHandler : EfUseCaseHandler<EditProductUseCase, Empty>
    {
        private readonly IMapper _mapper;
        public EditProductUseCaseHandler(ShopDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public override Empty Handle(EditProductUseCase useCase)
        {
            var data = useCase.Data;

            var product = _context.Products.Find(data.Id);

            _mapper.Map(data, product);

            _context.ProductSpecifications.RemoveRange(product.ProductSpecifications.Where(x => x.IsActive.Value));

            foreach (var spec in data.Specifications)
            {
                spec.ProductId = data.Id;
            }

            _context.ProductSpecifications.AddRange(_mapper.Map<IEnumerable<ProductSpecification>>(data.Specifications));

            _context.SaveChanges();

            return new Empty();
        }
    }
}
