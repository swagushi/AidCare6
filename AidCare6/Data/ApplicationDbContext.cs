using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using AidCare6.Models;

namespace AidCare6.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<AidCare6.Models.members> members { get; set; }
        public DbSet<AidCare6.Models.donations> donations { get; set; }
        public DbSet<AidCare6.Models.events> events { get; set; }
    }
}
