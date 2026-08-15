using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public sealed class Admin : BaseEntity
    {

        public required string FullName { get; private set; }
        public required string Email { get; private set; }
        public UserRole Role { get; private set; } = UserRole.Admin;


        //EF CORE
        public Admin() { }
    }
}
