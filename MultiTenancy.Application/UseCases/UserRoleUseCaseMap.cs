﻿using MultiTenancy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases
{
    public static class UserRoleUseCaseMap
    {
        private static Dictionary<UserRole, IEnumerable<string>> Map => new Dictionary<UserRole, IEnumerable<string>>
        {
            { UserRole.SuperUserGlobal, new List<string> { "SearchTestUseCase", "AddTestUseCase", "ExecuteTestUseCase", "SearchCategoriesUseCase",
                                                           "FindCategoryUseCase", "EditCategoryUseCase", "DeleteCategoryUseCase", "SearchProductsUseCase",
                                                           "FindProductUseCase", "EditProductUseCase", "DeleteProductUseCase", "SearchSpecificationsUseCase",
                                                           "FindSpecificationUseCase", "EditSpecificationUseCase", "DeleteSpecificationUseCase" } },

            { UserRole.SuperUserTenant, new List<string> { "SearchTestUseCase", "SearchCategoriesUseCase", "FindCategoryUseCase", "AddCategoryUseCase",
                                                           "EditCategoryUseCase", "DeleteCategoryUseCase", "SearchProductsUseCase", "FindProductUseCase",
                                                           "AddProductUseCase", "EditProductUseCase", "DeleteProductUseCase", "AddImageUseCase", "SearchSpecificationsUseCase",
                                                           "FindSpecificationUseCase", "AddSpecificationUseCase", "EditSpecificationUseCase", "DeleteSpecificationUseCase" } },

            { UserRole.User, new List<string> { "SearchCategoriesUseCase", "SearchProductsUseCase" } },

            { UserRole.Anonymous, new List<string> { "SearchCategoriesUseCase", "SearchProductsUseCase", "RegisterUseCase" } }
        };

        public static IEnumerable<string> GetUseCases(UserRole role) => Map[role];
    }
}
