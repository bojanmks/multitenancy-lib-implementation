﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Categories
{
    public class DeleteCategoryUseCase : UseCase<int>
    {
        public DeleteCategoryUseCase(int data) : base(data)
        {
        }

        public override string Id => "DeleteCategoryUseCase";
    }
}
