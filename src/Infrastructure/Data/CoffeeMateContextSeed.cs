using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public static class CoffeeMateContextSeed
    {
        public async static Task SeedAsync(CoffeeMateContext db)
        {
            if (await db.Products.AnyAsync())
                return;

            var products = new List<Product>
            {
                new Product { Name = "Caramel Macchiato", Description = "A delightful caramel-infused macchiato.", Price = 4.99m, PictureUri = "01.png", StockAmount = 100 },
                new Product { Name = "Hazelnut Latte", Description = "A rich latte with the essence of hazelnuts.", Price = 5.49m, PictureUri = "02.png", StockAmount = 100 },
                new Product { Name = "Iced Caramel Frappuccino", Description = "An Italian classic - strong espresso with a twist of lemon.", Price = 3.99m, PictureUri = "03.png", StockAmount = 100 },
                new Product { Name = "Mocha Cappuccino", Description = "A creamy cappuccino infused with the rich flavor of chocolate.", Price = 5.99m, PictureUri = "04.png", StockAmount = 100 },
                new Product { Name = "Vanilla Latte", Description = "Smooth and sweet latte with a hint of vanilla.", Price = 4.79m, PictureUri = "05.png", StockAmount = 100 },
                new Product { Name = "Cinnamon Espresso", Description = "A warming blend of coffee, Irish whiskey, sugar, and cream.", Price = 6.49m, PictureUri = "06.png", StockAmount = 100 }
            };

            db.AddRange(products);
            await db.SaveChangesAsync();
        }
    }
}
