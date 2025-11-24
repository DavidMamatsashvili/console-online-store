using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Models;
using Microsoft.EntityFrameworkCore;

namespace console_online_store.Data
{
    public partial class StoreDbContext : DbContext
    {
        public StoreDbContext()
        {
        }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; }

        public virtual DbSet<CartItem> CartItems { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<CustomerOrder> CustomerOrders { get; set; }

        public virtual DbSet<CustomerOrderDetail> CustomerOrderDetails { get; set; }

        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        public virtual DbSet<OrderState> OrderStates { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<ProductTitle> ProductTitles { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
            => optionsBuilder.UseSqlServer("Data Source=DESKTOP-2RL2NRE\\SQLEXPRESS;Initial Catalog=console_online_store;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Carts__3214EC0738587422");

                entity.HasIndex(e => e.UserId, "UQ__Carts__1788CC4DD649A42A").IsUnique();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

                entity.HasOne(d => d.User).WithOne(p => p.Cart)
                    .HasForeignKey<Cart>(d => d.UserId)
                    .HasConstraintName("FK__Carts__UserId__656C112C");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__CartItem__3214EC0719FB82A0");

                entity.HasIndex(e => new { e.CartId, e.ProductId }, "UQ_Cart_Product").IsUnique();

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK__CartItems__CartI__6B24EA82");

                entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItems__Produ__6C190EBB");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC073FCB996B");

                entity.Property(e => e.CategoryName).HasMaxLength(200);
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07B6F443E8");

                entity.Property(e => e.OperationTime).HasDefaultValueSql("(sysutcdatetime())");
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Customer).WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerO__Custo__70DDC3D8");

                entity.HasOne(d => d.OrderState).WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.OrderStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerO__Order__71D1E811");
            });

            modelBuilder.Entity<CustomerOrderDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0726900C26");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CustomerOrder).WithMany(p => p.CustomerOrderDetails)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .HasConstraintName("FK__CustomerO__Custo__76969D2E");

                entity.HasOne(d => d.Product).WithMany(p => p.CustomerOrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerO__Produ__778AC167");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Manufact__3214EC07E4E09F18");

                entity.Property(e => e.ManufacturerName).HasMaxLength(200);
            });

            modelBuilder.Entity<OrderState>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__OrderSta__3214EC07353B449F");

                entity.HasIndex(e => e.StateName, "UQ__OrderSta__55476315AE004483").IsUnique();

                entity.Property(e => e.StateName).HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Products__3214EC07724DAE01");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Manufa__5DCAEF64");

                entity.HasOne(d => d.ProductTitle).WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTitleId)
                    .HasConstraintName("FK__Products__Produc__5CD6CB2B");
            });

            modelBuilder.Entity<ProductTitle>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__ProductT__3214EC075E7C7626");

                entity.Property(e => e.ProductTitle1)
                    .HasMaxLength(300)
                    .HasColumnName("ProductTitle");

                entity.HasOne(d => d.Category).WithMany(p => p.ProductTitles)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__ProductTi__Categ__571DF1D5");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Users__3214EC073D3DD8D8");

                entity.HasIndex(e => e.Login, "UQ__Users__5E55825B7C8BB363").IsUnique();

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.Login).HasMaxLength(200);
                entity.Property(e => e.PasswordHash).HasMaxLength(300);
                entity.Property(e => e.IsBanned).IsRequired().HasDefaultValue(false);

                entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__UserRoleI__5441852A");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__UserRole__3214EC075AE6C6FD");

                entity.HasIndex(e => e.UserRoleName, "UQ__UserRole__518ED90AEA021566").IsUnique();

                entity.Property(e => e.UserRoleName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
