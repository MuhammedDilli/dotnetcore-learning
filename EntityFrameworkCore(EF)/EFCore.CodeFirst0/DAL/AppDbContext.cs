using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore.CodeFirst0.DAL
{
    public class AppDbContext :DbContext
    {


       // public DbSet<Person> People { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductFeature> ProductFeature { get; set; }

        public DbSet<Product> Products { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Initializer.Build();
            optionsBuilder.LogTo(Console.WriteLine,Microsoft.Extensions.Logging.LogLevel.Information).UseSqlServer
            (Initializer.Configuration.GetConnectionString("SqlCon"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var category = new Category() { Name="Defterler"};
            category.Products.Add(new() { Name = "Defterler 1", Price = 100, Stock = 200, Barcode = 123 });
            category.Products.Add(new() { Name = "Defterler 2", Price = 100, Stock = 200, Barcode = 123 });







            //her zaman has ile başlanıyor
            //    modelBuilder.Entity<Category>().HasMany(x=>x.Products).WithOne(x=>x.Category).HasForeignKey(x=>x.Category_Id);// çok a 1 ilişki n-1

            modelBuilder.Entity<Product>().HasOne(x => x.ProductFeature).WithOne(x => x.Product).HasForeignKey<ProductFeature>(x => x.ProductRef_Id);


        //    modelBuilder.Entity<Product>().ToTable("ProductTBB", "products"); //2.yol configuration tablo isim ekleme
            
            base.OnModelCreating(modelBuilder);
        }
        public override int SaveChanges()
        {
            //ChangeTracker.Entries().ToList().ForEach(e =>
            //  {
            //      if (e.Entity is Product p)
            //      {
            //          if (e.State == EntityState.Added)
            //          {
            //              p.CretedDate = DateTime.Now;
            //          }
            //      }
            //  });
            return base.SaveChanges();
        }
    }
}



