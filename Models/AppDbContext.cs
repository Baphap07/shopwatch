using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ShowWatch.Models
{
    public class AppDbContext: IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Product> products { get; set; }
        public DbSet<Category> Categories { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1433; Database=Product2;User=sa; Password=reallyStrongPwd123");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
               new Product()
               {
                   Id = 1,
                   Name = "Cityzen E5",
                   Brand = "CITYZEN",
                   Radius = "36mm",
                   Thickness = "5mm",
                   Cord = "leather",
                   Glasses = "Sapphire",
                   water_proof = "3 ATM",
                   Guarantee = "2 Year",
                   Avatar = "img/anh1.jpg",
                   Price = 5000000,
                   CategoryId=2
               }
                  
              );
            modelBuilder.Entity<Category>().HasData(
               new Category()
               {
                  CategoryId=1,
                  CategoryName="Casio"

               },
               new Category()
               {
                   CategoryId = 2,
                   CategoryName = "CityZen"

               }
              );
        }
    }
}
