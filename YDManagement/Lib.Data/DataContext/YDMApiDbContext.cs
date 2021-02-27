using System;
using Lib.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace Lib.Data.DataContext
{
    public class YDMApiDbContext : DbContext
    {
        public YDMApiDbContext(DbContextOptions<YDMApiDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed data
            // Customer
            modelBuilder.Entity<Customer>().HasData(
                    new Customer
                    {
                        Id = 1,
                        IsDeleted = false,
                        Name = "YONG",
                        Address = "HN"
                    }
            );

            // Category
            modelBuilder.Entity<Category>().HasData(
                   new Category
                   {
                       Id = 1,
                       IsDeleted = false,
                       Name = "Adidas",
                       Description = "Adidas is a multinational firm which was founded in 1948. The firs specialized in designing and manufacturing of sports clothing and accessories."
                   },
                    new Category
                    {
                        Id = 2,
                        IsDeleted = false,
                        Name = "Nike",
                        Description = "It was founded in 1964 as Blue Ribbon Sports by Bill Bowerman, a track-and-field coach at the University of Oregon, and his former student Phil Knight. " +
                        "They opened their first retail outlet in 1966 and launched the Nike brand shoe in 1972."
                    }
           );

            // Product
            modelBuilder.Entity<Product>().HasData(
                   new Product
                   {
                       Id = 1,
                       IsDeleted = false,
                       Name = "STAN SMITH",
                       CategoryId = 1,
                       Price = 2300000,
                       Description = "Timeless appeal. Effortless style. Everyday versatility. For over 50 years and counting, adidas Stan Smith Shoes have continued to hold their place as an icon. " +
                       "This pair shows off a fresh redesign as part of adidas' commitment to use only recycled polyester by 2024. Plus, they have an outsole made from rubber waste add to the classic style. " +
                       "This product is made with Primegreen, a series of high - performance recycled materials. 50 % of upper is recycled content. No virgin polyester.",
                       Quanity = 100
                   },
                   new Product
                   {
                       Id = 2,
                       IsDeleted = false,
                       Name = "Nike Rise 365 BRS",
                       CategoryId = 2,
                       Price = 1279000,
                       Description = "The Nike Rise 365 Top delivers versatile performance for everyday running. Designed for lightweight mobility, " +
                       "the top features soft fabric with increased ventilation where you need it most.",
                       Quanity = 100
                   }
           );
            #endregion

            #region ref
            // product - category
            modelBuilder.Entity<Product>()
              .HasOne<Category>(sc => sc.Category)
              .WithMany(s => s.Products)
              .HasForeignKey(sc => sc.CategoryId);

            // order - customer
            modelBuilder.Entity<Order>()
               .HasOne<Customer>(sc => sc.Customer)
               .WithMany(s => s.Orders)
               .HasForeignKey(sc => sc.CustomerId);

            // order - product
            modelBuilder.Entity<Order>()
                 .HasOne<Product>(sc => sc.Product)
                 .WithMany(s => s.Orders)
                 .HasForeignKey(sc => sc.ProductId);
            #endregion
        }
    }
}
