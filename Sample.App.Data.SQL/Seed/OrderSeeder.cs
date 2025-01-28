using Sample.App.Data.SQL.Context;
using Sample.App.Domain.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.App.Data.SQL.Seed
{
    public class OrderSeeder
    {
        public static void Seed(InventoryDBContext context)
        {
            List<Order> orders = new List<Order> {
                new Order { Id = 1, ProductId = 1, Quantity = 2 },
                new Order { Id = 2, ProductId = 2, Quantity = 1 },
                new Order { Id = 3, ProductId = 3, Quantity = 5 }
            };
            context.Orders.AddRange(orders);
            context.SaveChanges();
        }
    }
}
