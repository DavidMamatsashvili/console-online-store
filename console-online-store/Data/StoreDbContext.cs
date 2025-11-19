using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using console_online_store.Models;
using Microsoft.EntityFrameworkCore;

namespace console_online_store.Data
{
    //public class StoreDbContext : DbContext
    //{
    //    public StoreDbContext() { }
    //    public StoreDbContext(DbContextOptions options) : base(options)
    //    {
    //    }
    //    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    //    {
    //        builder.UseSqlServer(@"DESKTOP-2RL2NRE\SQLEXPRESS;Initial Catalog=UserProducts;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");
    //    }
    //}
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
        public string connectionnew = @"Data Source=DESKTOP-2RL2NRE\SQLEXPRESS;Initial Catalog=console_online_store;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
        public string connectionold = "Server=DESKTOP-2RL2NRE\\SQLEXPRESS;Database=console_online_store;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;";

        //        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        //            => optionsBuilder.UseSqlServer(connectionnew);
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-2RL2NRE\SQLEXPRESS;Database=console_online_store;Trusted_Connection=True;Encrypt=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Carts__3214EC07C710F779");

                entity.HasIndex(e => e.UserId, "UQ__Carts__1788CC4D94D7E11C").IsUnique();

                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");

                entity.HasOne(d => d.User).WithOne(p => p.Cart)
                    .HasForeignKey<Cart>(d => d.UserId)
                    .HasConstraintName("FK__Carts__UserId__6477ECF3");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__CartItem__3214EC0709C98A13");

                entity.HasIndex(e => new { e.CartId, e.ProductId }, "UQ_Cart_Product").IsUnique();

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Cart).WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .HasConstraintName("FK__CartItems__CartI__6A30C649");

                entity.HasOne(d => d.Product).WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItems__Produ__6B24EA82");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC0760F0E11D");

                entity.Property(e => e.CategoryName).HasMaxLength(200);
            });

            modelBuilder.Entity<CustomerOrder>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC075187F4AA");

                entity.Property(e => e.OperationTime).HasDefaultValueSql("(sysutcdatetime())");
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Customer).WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerO__Custo__6FE99F9F");

                entity.HasOne(d => d.OrderState).WithMany(p => p.CustomerOrders)
                    .HasForeignKey(d => d.OrderStateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerO__Order__70DDC3D8");
            });

            modelBuilder.Entity<CustomerOrderDetail>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07A88F2EB7");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.CustomerOrder).WithMany(p => p.CustomerOrderDetails)
                    .HasForeignKey(d => d.CustomerOrderId)
                    .HasConstraintName("FK__CustomerO__Custo__75A278F5");

                entity.HasOne(d => d.Product).WithMany(p => p.CustomerOrderDetails)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CustomerO__Produ__76969D2E");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Manufact__3214EC07FE55FCEF");

                entity.Property(e => e.ManufacturerName).HasMaxLength(200);
            });

            modelBuilder.Entity<OrderState>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__OrderSta__3214EC07BAF32DD3");

                entity.HasIndex(e => e.StateName, "UQ__OrderSta__554763151835F640").IsUnique();

                entity.Property(e => e.StateName).HasMaxLength(100);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Products__3214EC070ED1786F");

                entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                    .HasForeignKey(d => d.ManufacturerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Products__Manufa__5CD6CB2B");

                entity.HasOne(d => d.ProductTitle).WithMany(p => p.Products)
                    .HasForeignKey(d => d.ProductTitleId)
                    .HasConstraintName("FK__Products__Produc__5BE2A6F2");
            });

            modelBuilder.Entity<ProductTitle>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__ProductT__3214EC070773C6A1");

                entity.Property(e => e.ProductTitle1)
                    .HasMaxLength(300)
                    .HasColumnName("ProductTitle");

                entity.HasOne(d => d.Category).WithMany(p => p.ProductTitles)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__ProductTi__Categ__5629CD9C");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Users__3214EC078502F150");

                entity.HasIndex(e => e.Login, "UQ__Users__5E55825B3CD690D8").IsUnique();

                entity.Property(e => e.Balance).HasColumnType("decimal(18, 2)");
                entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
                entity.Property(e => e.FirstName).HasMaxLength(100);
                entity.Property(e => e.LastName).HasMaxLength(100);
                entity.Property(e => e.Login).HasMaxLength(200);
                entity.Property(e => e.PasswordHash).HasMaxLength(300);
                entity.Property(e => e.IsBanned).HasDefaultValue(false);

                entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                    .HasForeignKey(d => d.UserRoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__UserRoleI__534D60F1");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__UserRole__3214EC07F2BBFA3F");

                entity.HasIndex(e => e.UserRoleName, "UQ__UserRole__518ED90AE894782D").IsUnique();

                entity.Property(e => e.UserRoleName).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }

}
