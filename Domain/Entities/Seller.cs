using Domain.Enums;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public sealed class User : BaseEntity
    {
        public required string FullName { get; private set; }
        public required string Email { get; private set; }
        public UserRole Role { get; private set; } = UserRole.User;
        public ICollection<Product> Products { get; private set; }
        public Address? Address { get; private set; }
        
        //EF CORE
        public User() { }

        public static User Create(string fullName, string email, UserRole role, Address? address = null)
        {
            var user = new User
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
