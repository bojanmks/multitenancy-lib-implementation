using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Categories;
using MultiTenancy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.UseCases.Handlers.Categories
{
    public class DeleteCategoryUseCaseHandler : EfUseCaseHandler<DeleteCategoryUseCase, Empty>
    {
        public DeleteCategoryUseCaseHandler(ShopDbContext context) : base(context)
        {
        }

        public override Empty Handle(DeleteCategoryUseCase useCase)
        {
            var id = useCase.Data;

            var category = _context.Categories.Find(id);

            _context.CategorySpecifications.RemoveRange(category.CategorySpecifications.Where(x => x.IsActive.Value));

            _context.Categories.Remove(category);

            _context.SaveChanges();

            return new Empty();
        }
    }
}
