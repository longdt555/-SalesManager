using System;
using System.ComponentModel.DataAnnotations.Schema;
using Lib.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lib.Data.DataContext
{
    public class YdmApiDbContext : DbContext
    {
        public YdmApiDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // #region Seed data
            // // Customer
            // modelBuilder.Entity<Customer>().HasData(
            //         new Customer
            //         {
            //             Id = Guid.NewGuid(),
            //             IsDeleted = false,
            //             Name = "YONG",
            //             Address = "HN",
            //             UserName = "YongDT",
            //             Password = "836e5d18d15f021bb70d5f97f0a1c0b0"
            //         }
            // );

            // // Category
            // modelBuilder.Entity<Category>().HasData(
            //        new Category
            //        {
            //            Id = Guid.NewGuid(),
            //            IsDeleted = false,
            //            Name = "Adidas",
            //            Description = "Adidas is a multinational firm which was founded in 1948. The firs specialized in designing and manufacturing of sports clothing and accessories."
            //        },
            //         new Category
            //         {
            //             Id = Guid.NewGuid(),
            //             IsDeleted = false,
            //             Name = "Nike",
            //             Description = "It was founded in 1964 as Blue Ribbon Sports by Bill Bowerman, a track-and-field coach at the University of Oregon, and his former student Phil Knight. " +
            //             "They opened their first retail outlet in 1966 and launched the Nike brand shoe in 1972."
            //         }
            //);

            // // Product
            // modelBuilder.Entity<Product>().HasData(
            //        new Product
            //        {
            //            Id = Guid.NewGuid(),
            //            IsDeleted = false,
            //            Name = "STAN SMITH",
            //            CategoryId = Guid.Parse("32e73e93-3c72-491f-b5dc-be00d0b1837d"),
            //            Price = 2300000,
            //            Description = "Timeless appeal. Effortless style. Everyday versatility. For over 50 years and counting, adidas Stan Smith Shoes have continued to hold their place as an icon. " +
            //            "This pair shows off a fresh redesign as part of adidas' commitment to use only recycled polyester by 2024. Plus, they have an outsole made from rubber waste add to the classic style. " +
            //            "This product is made with Primegreen, a series of high - performance recycled materials. 50 % of upper is recycled content. No virgin polyester.",
            //            Quantity = 100
            //        },
            //        new Product
            //        {
            //            Id = Guid.NewGuid(),
            //            IsDeleted = false,
            //            Name = "Nike Rise 365 BRS",
            //            CategoryId = Guid.Parse("96f1b35d-5a93-4362-bd88-a5172d19ce62"),
            //            Price = 1279000,
            //            Description = "The Nike Rise 365 Top delivers versatile performance for everyday running. Designed for lightweight mobility, " +
            //            "the top features soft fabric with increased ventilation where you need it most.",
            //            Quantity = 100
            //        }
            //);
            // #endregion

            #region ref
            // product - category
            modelBuilder.Entity<Product>()
              .HasOne(sc => sc.Category)
              .WithMany(s => s.Products)
              .HasForeignKey(sc => sc.CategoryId);

            // order - customer
            modelBuilder.Entity<Order>()
               .HasOne(sc => sc.Customer)
               .WithMany(s => s.Orders)
               .HasForeignKey(sc => sc.CustomerId);

            // order - product
            modelBuilder.Entity<Order>()
                 .HasOne(sc => sc.Product)
                 .WithMany(s => s.Orders)
                 .HasForeignKey(sc => sc.ProductId);
            #endregion
        }
    }
}
