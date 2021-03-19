using System;
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
        public DbSet<CustomerCart> CustomerCarts { get; set; }
        public DbSet<CustomerProfile> CustomerProfiles { get; set; }
        public DbSet<ExpiredLink> ExpiredLinks { get; set; }
        public DbSet<SystemSettings> SystemSettingss { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionDetail> TransactionDetails { get; set; }
        public DbSet<BackendUser> BackendUsers { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seed data
            // role
            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    IsDeleted = false,
                    Title = "Administrator"
                },
                new Role
                {
                    Id = 2,
                    IsDeleted = false,
                    Title = "Supporter"
                },
                new Role
                {
                    Id = 3,
                    IsDeleted = false,
                    Title = "Editor"
                }
            );

            // backend user
            modelBuilder.Entity<BackendUser>().HasData(
                new BackendUser
                {
                    Id = 1,
                    UserName = "Admin",
                    Password = "77035d7402f0bde20eeaaf775731d099",
                    FirstName = "Admin",
                    LastName = "Mr",
                    RoleId = 1,
                    CreatedDate = DateTime.Now
                });

            // Customer
            modelBuilder.Entity<Customer>().HasData(
                    new Customer
                    {
                        Id = 1,
                        Email = "longdt555@gmail.com",
                        Password = "e10adc3949ba59abbe56e057f20f883e",
                        IsDeleted = false,
                        Name = "YONG",
                        CreatedDate = DateTime.Now
                    }
            );

            // Category
            modelBuilder.Entity<Category>().HasData(
                   new Category
                   {
                       Id = 1,
                       IsDeleted = false,
                       Name = "Adidas",
                       Description = "Adidas is a multinational firm which was founded in 1948. The firs specialized in designing and manufacturing of sports clothing and accessories.",
                       CreatedDate = DateTime.Now
                   },
                    new Category
                    {
                        Id = 2,
                        IsDeleted = false,
                        Name = "Nike",
                        Description = "It was founded in 1964 as Blue Ribbon Sports by Bill Bowerman, a track-and-field coach at the University of Oregon, and his former student Phil Knight. " +
                        "They opened their first retail outlet in 1966 and launched the Nike brand shoe in 1972.",
                        CreatedDate = DateTime.Now
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
                       Quantity = 100,
                       CreatedDate = DateTime.Now
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
                       Quantity = 100,
                       CreatedDate = DateTime.Now
                   }
           );
            #endregion

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

            // backend user - role
            modelBuilder.Entity<BackendUser>()
                .HasOne(sc => sc.Role)
                .WithMany(s => s.BackendUsers)
                .HasForeignKey(sc => sc.RoleId);

            // transaction - user
            modelBuilder.Entity<Transaction>()
                .HasOne(sc => sc.Customer)
                .WithMany(s => s.Transactions)
                .HasForeignKey(sc => sc.CustomerId);

            modelBuilder.Entity<Transaction>()
                .HasOne(sc => sc.CustomerCart)
                .WithMany(s => s.Transactions)
                .HasForeignKey(sc => sc.CustomerCartId);

            // transaction detail - transaction
            modelBuilder.Entity<TransactionDetail>()
                .HasOne(sc => sc.Transaction)
                .WithMany(s => s.TransactionDetails)
                .HasForeignKey(sc => sc.TransactionId);

            // Customer cart - customer
            modelBuilder.Entity<CustomerCart>()
                .HasOne(sc => sc.Customer)
                .WithMany(s => s.CustomerCarts)
                .HasForeignKey(sc => sc.CustomerId);

            // Customer cart - product
            modelBuilder.Entity<CustomerCart>()
                .HasOne(sc => sc.Product)
                .WithMany(s => s.CustomerCarts)
                .HasForeignKey(sc => sc.ProductId);
        }
    }
}
