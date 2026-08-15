using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public sealed class Buyer : BaseEntity
    {
        public required string FullName { get; private set; }
        public required string Email { get; private set; }
        public UserRole Role { get; private set; } = UserRole.Buyer;
        public ICollection<Product> Products { get; private set; }
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
