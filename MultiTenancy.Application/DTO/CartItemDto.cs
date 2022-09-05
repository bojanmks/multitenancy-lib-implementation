using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiTenancy.Domain;

namespace MultiTenancy.Application.DTO
{
    public class CartItemDto : BaseDto
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public int Quantity { get; set; }
        public int? UserId { get; set; }
        public string? Username { get; set; }
    }
}
