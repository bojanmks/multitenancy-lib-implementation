using AutoMapper;
using MultiTenancy.Application.UseCases;
using MultiTenancy.Application.UseCases.Category;
using MultiTenancy.DataAccess;
using MultiTenancy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.UseCases.Handlers.Categories
{
    public class AddCategoryUseCaseHandler : EfUseCaseHandler<AddCategoryUseCase, Empty>
    {
        private readonly IMapper _mapper;
        public AddCategoryUseCaseHandler(ShopDbContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public override Empty Handle(AddCategoryUseCase useCase)
        {
            var data = useCase.Data;

            var category = _mapper.Map<Category>(data);

            _context.Categories.Add(category);

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
