using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Sample.App.Domain.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.App.Data.SQL.Context
{
    public class InventoryDBContext:DbContext
    {
        private readonly IConfiguration _configuration;

        public InventoryDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
            // select Data project
            //dotnet ef migrations add InitialMigration --project Sample.App.Data.SQL --startup-project Sample.App.Web

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Products
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Laptop", Price = 1200.00m },
                new Product { Id = 2, Name = "Smartphone", Price = 800.00m },
                new Product { Id = 3, Name = "Headphones", Price = 150.00m }
            );

            // Seed data for Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, ProductId = 1, Quantity = 2 },
                new Order { Id = 2, ProductId = 2, Quantity = 1 },
                new Order { Id = 3, ProductId = 3, Quantity = 5 }
            );
        }
    }
}
