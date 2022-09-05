using MultiTenancy.Domain.Enums;
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
                                                           "FindSpecificationUseCase", "EditSpecificationUseCase", "DeleteSpecificationUseCase", "AddTenantUseCase",
                                                           "EditTenantUseCase", "DeleteTenantUseCase", "SearchTenantsUseCase", "FindTenantUseCase", "AddCountryUseCase",
                                                           "EditCountryUseCase", "DeleteCountryUseCase", "SearchCountriesUseCase", "FindCountryUseCase" } },

            { UserRole.SuperUserTenant, new List<string> { "SearchTestUseCase", "SearchCategoriesUseCase", "FindCategoryUseCase", "AddCategoryUseCase",
                                                           "EditCategoryUseCase", "DeleteCategoryUseCase", "SearchProductsUseCase", "FindProductUseCase",
                                                           "AddProductUseCase", "EditProductUseCase", "DeleteProductUseCase", "AddImageUseCase", "SearchSpecificationsUseCase",
                                                           "FindSpecificationUseCase", "AddSpecificationUseCase", "EditSpecificationUseCase", "DeleteSpecificationUseCase",
                                                           "SearchCountriesUseCase" } },

            { UserRole.User, new List<string> { "SearchCategoriesUseCase", "SearchProductsUseCase", "SearchCountriesUseCase" } },

            { UserRole.Anonymous, new List<string> { "SearchCategoriesUseCase", "SearchProductsUseCase", "RegisterUseCase", "SearchCountriesUseCase" } }
        };

        public static IEnumerable<string> GetUseCases(UserRole role) => Map[role];
    }
}
