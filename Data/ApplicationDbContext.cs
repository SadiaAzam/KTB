using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using KTB.Models;

namespace KTB.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<KTB.Models.Fruit> Fruit { get; set; }
        public DbSet<KTB.Models.Vendor> Vendor { get; set; }
        public DbSet<KTB.Models.Employee> Employee { get; set; }
        public DbSet<KTB.Models.Order> Order { get; set; }
        public DbSet<KTB.Models.VendorsofFruits> VendorsofFruits { get; set; }
    }
}
