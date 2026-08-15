using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public sealed class Seller : BaseEntity
    {
        public required string FullName { get; init; }
        public required string Email { get; init; }
        public UserRole Role { get; private set; } = UserRole.Seller;
        // Navigation property
        public ICollection<Product> Products { get; private set; } = new List<Product>();
        public Address? Address { get; private set; }
        
        //EF CORE
        public Seller() { }

        public static Seller Create(string fullName, string email, UserRole role, Address? address = null)
        {
            var user = new Seller
            {
                FullName = fullName,
                Email = email,
                Role = role,
                Address = address
            };

            user.setCreatedAt(DateTime.UtcNow);
            return user;
        }

        public void UpdateAddress(Address newAddress)
        {
            Address = newAddress;
            setUpdatedAt(DateTime.UtcNow);
        }
    }
}
