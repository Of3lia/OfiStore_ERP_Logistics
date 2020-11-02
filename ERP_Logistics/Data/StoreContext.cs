using ERP_Logistics.Controllers;
using ERP_Logistics.Migrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP_Logistics.Models
{
    public class StoreContext : DbContext
    {
        public StoreContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<OrderClient> OrderClients{ get; set; }
        public DbSet<OrderEmployee> OrderEmployees { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.UserName)
                .IsUnique();

            builder.Entity<OrderProduct>()
                .HasOne(o => o.Order)
                .WithMany(c => c.OrderProducts)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<OrderClient>()
            //    .HasOne(o => o.Client)
            //    .WithOne(o => o.Orders)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<Order>()
            //    .HasOne(o => o.Order)
            //    .WithMany(c => c.OrderProducts)
            //    .IsRequired()
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.Entity<ApplicationUser>(entity =>
            //{
            //    entity.ToTable(name: "Id");
            //    entity.Property(e => e.Id).HasColumnName("UserId");

            //});
        }
    }
}
