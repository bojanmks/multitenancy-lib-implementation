using FluentValidation;
using MultiTenancy.Application.UseCases.Test;
using MultiTenancy.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Validators.Test
{
    public class ExecuteTestValidator : AbstractValidator<ExecuteTestUseCase>
    {
        public ExecuteTestValidator(ShopDbContext context)
        {
            RuleFor(x => x.Data)
                .NotEmpty()
                .WithMessage("Data is required")
                .Must(x => !context.Test.Any(y => y.Name == $"Test {x}"))
                .WithMessage("Test with that name already exist");
        }
    }
}
