using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Products;
using MultiTenancy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.UseCases.Handlers.Products
{
    public class DeleteProductUseCaseHandler : EfUseCaseHandler<DeleteProductUseCase, Empty>
    {
        public DeleteProductUseCaseHandler(ShopDbContext context) : base(context)
        {
        }

        public override Empty Handle(DeleteProductUseCase useCase)
        {
            var id = useCase.Data;

            var product = _context.Products.Find(id);

            _context.ProductSpecifications.RemoveRange(product.ProductSpecifications.Where(x => x.IsActive.Value));

            _context.Products.Remove(product);

            _context.SaveChanges();

            return new Empty();
        }
    }
}
