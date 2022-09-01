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
    public class AddProductUseCaseHandler : EfUseCaseHandler<AddProductUseCase, Empty>
    {
        private readonly IMapper _mapper;
        public AddProductUseCaseHandler(ShopDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public override Empty Handle(AddProductUseCase useCase)
        {
            var data = useCase.Data;

            var product = _mapper.Map<Product>(data);

            _context.Products.Add(product);

            var specifications = _mapper.Map<IEnumerable<ProductSpecification>>(data.Specifications);

            foreach (var spec in specifications)
            {
                spec.Product = product;
            }

            _context.ProductSpecifications.AddRange(specifications);

            _context.SaveChanges();

            return new Empty();
        }
    }
}
