using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public sealed class Order : BaseEntity
    {
        public required string OrderNumber { get; init; }
        public Guid BuyerId { get; private set; }
        //Navigation property
        public Buyer Buyer { get; private set; } = null!;
        public OrderStatus Status { get; private set; } = OrderStatus.Pending;
        public ICollection<Product> Products { get; private set; } = new List<Product>();
        //EF CORE
        public Order() { }

        public static Order Create(string orderNumber, Guid buyerId, ICollection<Product> products)
        {
            var order = new Order
            {
                OrderNumber = orderNumber,
                BuyerId = buyerId,
                Products = products
            };

            order.setCreatedAt(DateTime.UtcNow);
            return order;
        }

        public void UpdateStatus(OrderStatus newStatus)
        {
            Status = newStatus;
            setUpdatedAt(DateTime.UtcNow);
        }
    }
}
