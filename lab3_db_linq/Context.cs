using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab3_db_linq
{
    class Context: DbContext
    {

        public DbSet<Storehouse> Storehouse { get; set; }
        public DbSet<Product> Product { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Store;Trusted_Connection=True;");
        }
    }
}