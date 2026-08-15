using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public required string Name { get; init; }
        public string Description { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public ProductCategory Category { get; private set; } = ProductCategory.None;
        public int StockQuantity { get; private set; } = 0;
        public Guid SellerId { get; private set; }
        // Navigation property
        public Seller Seller { get; private set; } = null!;

        //EF CORE
        public Product()
        {
        }
        public static Product Create(string name, string description, decimal price, ProductCategory category, Guid sellerId)
        {
            var product = new Product
            {
                Name = name,
                Description = description,
                Price = price,
                Category = category,
                SellerId = sellerId
            };

            product.setCreatedAt(DateTime.UtcNow);

            return product;
        }
    }
}
