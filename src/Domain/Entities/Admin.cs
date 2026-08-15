using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public sealed class Admin : BaseEntity
    {

        public required string FullName { get; init; }
        public required string Email { get; init; }
        public UserRole Role { get; private set; } = UserRole.Admin;


        //EF CORE
        public Admin() { }
    }
}
