using Microsoft.EntityFrameworkCore;
using ECommerceApi.Domain.Entities;

namespace ECommerceApi.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<BasketItem> BasketItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<ProductHiyerarchy> ProductHiyerarchies { get; set; }
        public DbSet<ProductPrice> ProductPrices { get; set; }
        public DbSet<ProductStack> ProductStacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
                entity.Property(p => p.Name).HasMaxLength(100);
                entity.Property(p => p.Description).HasMaxLength(500);
            });

          
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);
                entity.Property(u => u.UserName).HasMaxLength(50);
                entity.Property(u => u.Email).HasMaxLength(100);
                entity.Property(u => u.Password).HasMaxLength(200);
            });

           
            modelBuilder.Entity<Basket>(entity =>
            {
                entity.HasKey(b => b.BasketId);
            });

         
            modelBuilder.Entity<BasketItem>(entity =>
            {
                entity.HasKey(bi => bi.BasketItemId);
                entity.Property(bi => bi.UnitPrice).HasColumnType("decimal(18,2)");
            });

         
            modelBuilder.Entity<Basket>()
                .HasMany(b => b.BasketItems)
                .WithOne(bi => bi.Basket)
                .HasForeignKey(bi => bi.BasketId)
                .OnDelete(DeleteBehavior.Cascade);

            
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderDetails)
                .WithOne(od => od.Order)
                .HasForeignKey(od => od.OrderId)
                .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.OrderId);
                entity.Property(o => o.TotalAmount).HasColumnType("decimal(18,2)");
            });

            
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(od => od.OrderDetailId);
                entity.Property(od => od.UnitPrice).HasColumnType("decimal(18,2)");
            });

       
            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.HasKey(pp => pp.ProductPriceId);
                entity.Property(pp => pp.Price).HasColumnType("decimal(18,2)");
                entity.Property(pp => pp.DiscountPrice).HasColumnType("decimal(18,2)");
            });

          
            modelBuilder.Entity<ProductStack>(entity =>
            {
                entity.HasKey(ps => ps.ProductStackId);
                entity.Property(ps => ps.Location).HasMaxLength(50);
            });

            
            modelBuilder.Entity<ProductHiyerarchy>(entity =>
            {
                entity.HasKey(ph => ph.ProductHiyerarchyId);
                entity.Property(ph => ph.CategoryName).HasMaxLength(100);
                entity.Property(ph => ph.CategoryPath).HasMaxLength(200);
            });
        }
    }
}
