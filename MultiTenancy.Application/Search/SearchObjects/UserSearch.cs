using MultiTenancy.Application.Search.Attributes;
using MultiTenancy.Application.Search.Enums;
using MultiTenancy.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.Search.SearchObjects
{
    public class UserSearch : BaseSearch
    {
        [QueryProperty(ComparisonType.Contains, "Username", "FullName", "Email")]
        public string? Keyword { get; set; }

        [QueryProperty(ComparisonType.Equals, "RoleId")]
        public byte? RoleId => (byte?)Role;

        [QueryProperty(ComparisonType.Equals, "TenantId")]
        public int? TenantId { get; set; }

        public UserRole? Role { get; set; }
    }
}
