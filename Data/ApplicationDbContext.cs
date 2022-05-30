using BusStationTickets.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusStationTickets.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        internal object categories;

        public DbSet<Cart> Carts { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Product>()
                   .HasOne(p => p.Category)
                   .WithMany(c => c.Products)
                   .HasForeignKey(p => p.CategoryId)
                   .HasConstraintName("FK_Products_CategoryId");
            
            builder.Entity<OrderDetails>()
                   .HasOne(p => p.Product)
                   .WithMany(c => c.OrderDetails)
                   .HasForeignKey(p => p.ProductId)
                   .HasConstraintName("FK_OrderDetails_ProductId");

            builder.Entity<Cart>()
                   .HasOne(p => p.Product)
                   .WithMany(c => c.Carts)
                   .HasForeignKey(p => p.ProductId)
                   .HasConstraintName("FK_Cart_ProductId");


        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
