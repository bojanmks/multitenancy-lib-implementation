using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MultiTenancy.Application.UseCases.Orders;
using MultiTenancy.DataAccess;
using MultiTenancy.Domain.Enums;

namespace MultiTenancy.Implementation.Validators.Orders
{
    //Enum.IsDefined(typeof(MyEnum), value)
    public class EditOrderValidator : AbstractValidator<EditOrderUseCase>
    {
        public EditOrderValidator()
        {
            RuleFor(x => x.Data.StatusId)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Status Id is required.")
                .Must(statusId => Enum.IsDefined(typeof(OrderStatus), (int)statusId))
                .WithMessage("Status with an Id of {PropertyValue} does not exist.");
        }
    }
}
