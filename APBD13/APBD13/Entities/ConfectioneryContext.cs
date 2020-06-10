using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace APBD13.Entities
{
    public class ConfectioneryContext : DbContext
    {
        public DbSet<Confectionery> Confectioneries { get; set; }
        public DbSet<ConfectioneryOrder> ConfectioneryOrders { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ConfectioneryContext()
        {

        }
        public ConfectioneryContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ConfectioneryOrder>(entity =>
            {
                entity.HasKey(e => new
                {
                    e.IdConfection,
                    e.IdOrder
                });
                entity.ToTable("ConfectioneryOrder");
            });
            builder.Entity<Confectionery>(entity =>
            {
                entity.HasKey(e => e.IdConfecti);
                entity.ToTable("Confectionery");

                entity.HasMany(conf => conf.ConfectioneryOrders)
                .WithOne(order => order.Confectionery)
                .HasForeignKey(order => order.IdConfection)
                .IsRequired();
            });

            builder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder);
                entity.ToTable("Orders");

                entity.HasMany(order => order.ConfectioneryOrders)
                .WithOne(conf => conf.Order)
                .HasForeignKey(conf => conf.IdOrder)
                .IsRequired();
            });

            builder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdClient);
                entity.ToTable("Customer");
                entity.HasMany(e => e.Orders)
                .WithOne(order => order.Customer)
                .HasForeignKey(order => order.IdCustomer)
                .IsRequired();
            });

            builder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.IdEmpl);
                entity.ToTable("Employee");
                entity.HasMany(e => e.Orders)
                .WithOne(order => order.Employee)
                .HasForeignKey(order => order.IdEmployee)
                .IsRequired();
            });

            
        }
    }
}
