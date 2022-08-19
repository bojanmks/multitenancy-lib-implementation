﻿using FluentValidation;
using MultiTenancy.Application.UseCases.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Implementation.Validators.Test
{
    public class SearchTestValidator : AbstractValidator<SearchTestUseCase>
    {
        public SearchTestValidator()
        {
            RuleFor(x => x.Data.Name)
                .NotEmpty()
                .WithMessage("Name is required.");
        }
    }
}
