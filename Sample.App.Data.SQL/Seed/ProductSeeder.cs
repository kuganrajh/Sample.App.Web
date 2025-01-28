using Sample.App.Data.SQL.Context;
using Sample.App.Domain.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.App.Data.SQL.Seed
{
    public class ProductSeeder
    {
        public static void Seed(InventoryDBContext context)
        {
            List<Product> products = new List<Product> {
                new Product { Id = 1, Name = "Laptop", Price = 1200.00m },
                new Product { Id = 2, Name = "Smartphone", Price = 800.00m },
                new Product { Id = 3, Name = "Headphones", Price = 150.00m }
            };
            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}
