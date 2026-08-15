using System;
using System.Collections.Generic;
using System.Text;
using Domain.Enums;
using Domain.ValueObjects;

namespace Domain.Entities
{
    public sealed class Buyer : BaseEntity
    {
        public required string FullName { get; init; }
        public required string Email { get; init; }
        public UserRole Role { get; private set; } = UserRole.Buyer;
        public ICollection<Product> Products { get; private set; } = new List<Product>();
        public Address? Address { get; private set; }

        //EF CORE
        public Buyer() { }

        public static Buyer Create(string fullName, string email, UserRole role, Address? address = null)
        {
            var buyer = new Buyer
            {
                FullName = fullName,
                Email = email,
                Role = role,
                Address = address
            };

            buyer.setCreatedAt(DateTime.UtcNow);
            return buyer;
        }

        public void UpdateAddress(Address newAddress)
        {
            Address = newAddress;
            setUpdatedAt(DateTime.UtcNow);
        }
    }
}
