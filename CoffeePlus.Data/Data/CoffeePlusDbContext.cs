using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using CoffeePlus.Data;

namespace CoffeePlus.Data.Data
{
    public partial class CoffeePlusDbContext : DbContext
    {
        public CoffeePlusDbContext() {}

        public CoffeePlusDbContext(DbContextOptions<CoffeePlusDbContext> options) : base(options) {}

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().ToCollection("products");
            modelBuilder.Entity<Order>().ToCollection("orders");
            modelBuilder.Entity<OrderItem>().ToCollection("order_items");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}