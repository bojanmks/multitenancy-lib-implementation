using MultiTenancy.Application.Search.SearchObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.UseCases.Users
{
    public class SearchUsersUseCase : UseCase<UserSearch>
    {
        public SearchUsersUseCase(UserSearch data) : base(data)
        {
        }

        public override string Id => "SearchUsersUseCase";
    }
}
