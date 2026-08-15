using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public sealed class Cart : BaseEntity
    {
        public Guid BuyerId { get; private set; }
        //Navigation property
        public Buyer Buyer { get; private set; } = null!;
        public int Count { get; private set; } = 0;
        public decimal TotalPrice { get; private set; } = 0;
        public ICollection<Product> Products { get; private set; } = new List<Product>();
        
        //EF CORE
        public Cart() { }

        public static Cart Create(Guid buyerId, ICollection<Product> products)
        {
            var cart = new Cart
            {
                BuyerId = buyerId,
                Products = products
            };

            cart.Count = products.Count;
            cart.TotalPrice = CalculateTotalPrice(products);
            cart.setCreatedAt(DateTime.UtcNow);
            return cart;
        }

        private static decimal CalculateTotalPrice(ICollection<Product> products)
        {
            decimal totalPrice = 0;

            foreach (var product in products)
            {
                totalPrice += product.Price;
            }
            return totalPrice;
        }
    }
}
