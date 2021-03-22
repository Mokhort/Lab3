using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab3_db_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            
                Context context = new Context();
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Product.Add(new Product()
                {
                    cost = 2000,
                    name = "Glasses",
                    vendor = "ZaRa"

                });
               Product prod1= new Product()
               {
                   cost = 1500,
                   name = "T-shirt",
                   vendor = "Mango"
               };
               context.Product.Add(prod1);
            
                context.Product.Add(new Product()
                {
                    cost = 4500,
                    name = "Bag",
                    vendor = "ZaRa"
                });
                context.Product.Add(new Product()
                {
                    cost = 150,
                    name = "Socks",
                    vendor = "Codered"
                });
                context.Storehouse.Add(new Storehouse()
                {
                    name = "storehouse1",
                    quantity = 200,
                });
                
               // Storehouse st1 = new Storehouse { name = "storehouse1", quantity = 200 };
               // st1.Products.Add();
                context.SaveChanges();

                //все товары в пределах цены
                IQueryable<Product> product = from pr in context.Product
                                               where pr.cost <= 2000
                                               select pr;
               
                List<Product> list = product.ToList();
                Console.WriteLine($" Product with a price below 2000:");
                foreach (Product products in product)
                    Console.WriteLine($"Name - {products.name} Price - {products.cost}");

            // sql
            //IQueryable<Product> Products = context.Product.FromSqlRaw(" Select * from Store.Product where  Store.Product.cost <=2000");

                Console.WriteLine($"===============================================");
            // все товары одного продавца
                IQueryable<Product> product2 = from pr in context.Product
                                          where pr.vendor == "ZaRa"
                                          select pr;

                List<Product> list2 = product2.ToList();
                Console.WriteLine($" Product with the same vendor (ZaRa):");
                foreach (Product products in product2)
                         Console.WriteLine($"ID - {products.id} Name - {products.name} Price - {products.cost}");

            // sql
            //IQueryable<Product> Products = context.Product.FromSqlRaw("Select * from Store.Product where  Store.Product.vendor = 'ZaRa'");

            Console.WriteLine($"===============================================");

            //товар по всем складам

            IQueryable<Storehouse> strhouse = from st in context.Storehouse
             
                                           where st.Product.Contains(prod1)
                                           select st;
  

            context.Dispose();
        }

    }
}