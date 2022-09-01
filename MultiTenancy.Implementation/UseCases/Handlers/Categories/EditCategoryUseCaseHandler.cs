using AutoMapper;
using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Categories;
using MultiTenancy.DataAccess;
using MultiTenancy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.UseCases.Handlers.Categories
{
    public class EditCategoryUseCaseHandler : EfUseCaseHandler<EditCategoryUseCase, Empty>
    {
        private readonly IMapper _mapper;
        public EditCategoryUseCaseHandler(ShopDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public override Empty Handle(EditCategoryUseCase useCase)
        {
            var data = useCase.Data;

            var category = _context.Categories.Find(data.Id);

            _mapper.Map(data, category);

            _context.CategorySpecifications.RemoveRange(category.CategorySpecifications.Where(x => x.IsActive.Value));

            _context.CategorySpecifications.AddRange(data.SpecificationIds.Select(specificationId => new CategorySpecification
            {
                SpecificationId = specificationId,
                Category = category
            }));

            _context.SaveChanges();

            return new Empty();
        }
    }
}
