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
                                                           "FindCategoryUseCase", "AddCategoryUseCase", "EditCategoryUseCase", "DeleteCategoryUseCase" } },
            { UserRole.SuperUserTenant, new List<string> { "SearchTestUseCase", "SearchCategoriesUseCase", "FindCategoryUseCase", "AddCategoryUseCase",
                                                           "EditCategoryUseCase", "DeleteCategoryUseCase" } },
            { UserRole.User, new List<string> { "SearchTestUseCase", "SearchCategoriesUseCase" } },
            { UserRole.Anonymous, new List<string> { "SearchTestUseCase", "SearchCategoriesUseCase" } }
        };

        public static IEnumerable<string> GetUseCases(UserRole role) => Map[role];
    }
}
