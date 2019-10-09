using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CRUDcars.Data;

namespace CRUDcars.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CRUDcars.Data.Manufacturers> Manufacturers { get; set; }
        public DbSet<CRUDcars.Data.cars> cars { get; set; }

    }
}
