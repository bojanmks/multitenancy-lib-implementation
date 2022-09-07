using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenancy.Application.DTO
{
    public class OrderDto : TenantOwnedDto
    {
        public byte StatusId { get; set; }
        public string Status { get; set; }
        public string DeliveryLocation { get; set; }
        public virtual ICollection<OrderItemDto> Items { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
    }

    public class AddOrderDto : BaseDto
    {
        public int AddressId { get; set; }
        public virtual ICollection<OrderItemDto> Items { get; set; }

    }

    public class EditOrderDto : BaseDto
    {
        public byte StatusId { get; set; }
    }
}
