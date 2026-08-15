using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Infrastructure.DbContext
{
    public class ApplicationDbContext : IdentityDbContext
    {
    }
}
