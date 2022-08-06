using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Web_Api.Models
{
    public partial class manager_sellerContext : DbContext
    {
        

        public manager_sellerContext(DbContextOptions<manager_sellerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AttributeModel> Attributes { get; set; } = null!;
        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Import> Imports { get; set; } = null!;
        public virtual DbSet<ImportDetail> ImportDetails { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Supplier> Suppliers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=KHANHDUYPC;Initial Catalog=manager_seller;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AttributeModel>(entity =>
            {
                entity.HasKey(e => e.AttributesId);

                entity.ToTable("attribute");

                entity.Property(e => e.AttributesId)
                    .ValueGeneratedNever()
                    .HasColumnName("attributesId");

                entity.Property(e => e.AttributesName)
                    .HasMaxLength(50)
                    .HasColumnName("attributesName");

                entity.Property(e => e.AttributesValue)
                    .HasMaxLength(50)
                    .HasColumnName("attributesValue");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("_brand");

                entity.Property(e => e.BrandId)
                    .ValueGeneratedNever()
                    .HasColumnName("brandId");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(50)
                    .HasColumnName("brandName");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("categoryId");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(100)
                    .HasColumnName("categoryName");

                entity.Property(e => e.ParentId).HasColumnName("parentId");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId);

                entity.ToTable("customer");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .HasColumnName("customerId");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.ContactNumber)
                    .HasMaxLength(15)
                    .HasColumnName("contactNumber");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId);

                entity.ToTable("employee");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(10)
                    .HasColumnName("employeeId");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.ContactEmp)
                    .HasMaxLength(15)
                    .HasColumnName("contactEmp");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Import>(entity =>
            {
                entity.HasKey(e => e.ImportId);

                entity.ToTable("import");

                entity.Property(e => e.ImportId)
                    .HasMaxLength(10)
                    .HasColumnName("importId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ImportById)
                    .HasMaxLength(10)
                    .HasColumnName("importById");

                entity.Property(e => e.ImportByName)
                    .HasMaxLength(50)
                    .HasColumnName("importByName");

                entity.Property(e => e.ImportDate)
                    .HasColumnType("datetime")
                    .HasColumnName("importDate");

                entity.Property(e => e.ImportStatus).HasColumnName("importStatus");

                entity.Property(e => e.Note)
                    .HasMaxLength(200)
                    .HasColumnName("note");

                entity.Property(e => e.SupplierId)
                    .HasMaxLength(10)
                    .HasColumnName("supplierId");

                entity.Property(e => e.SupplierName)
                    .HasMaxLength(50)
                    .HasColumnName("supplierName");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Imports)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK_import_supplier");
            });

            modelBuilder.Entity<ImportDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("import_detail");

                entity.Property(e => e.FullName)
                    .HasMaxLength(300)
                    .HasColumnName("fullName");

                entity.Property(e => e.IdProduct)
                    .HasMaxLength(10)
                    .HasColumnName("idProduct");

                entity.Property(e => e.ImportId)
                    .HasMaxLength(10)
                    .HasColumnName("importId");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_import_detail_product");

                entity.HasOne(d => d.Import)
                    .WithMany()
                    .HasForeignKey(d => d.ImportId)
                    .HasConstraintName("FK_import_detail_import");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("order");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(10)
                    .HasColumnName("orderId");

                entity.Property(e => e.CustomerId)
                    .HasMaxLength(10)
                    .HasColumnName("customerId");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .HasColumnName("customerName");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("orderDate");

                entity.Property(e => e.SoldById)
                    .HasMaxLength(10)
                    .HasColumnName("soldById");

                entity.Property(e => e.SoldByName)
                    .HasMaxLength(50)
                    .HasColumnName("soldByName");

                entity.Property(e => e.Total).HasColumnName("total");

                entity.Property(e => e.TotalPayment).HasColumnName("totalPayment");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_order_customer");

                entity.HasOne(d => d.SoldBy)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.SoldById)
                    .HasConstraintName("FK_order_employee");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("order_detail");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.FullName)
                    .HasMaxLength(300)
                    .HasColumnName("fullName");

                entity.Property(e => e.IdProduct)
                    .HasMaxLength(10)
                    .HasColumnName("idProduct");

                entity.Property(e => e.OrderId)
                    .HasMaxLength(10)
                    .HasColumnName("orderId");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SubTotal).HasColumnName("subTotal");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK_order_detail_product");

                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_order_detail_order");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct);

                entity.ToTable("product");

                entity.Property(e => e.IdProduct)
                    .HasMaxLength(10)
                    .HasColumnName("idProduct");

                entity.Property(e => e.AttributesId).HasColumnName("attributesId");

                entity.Property(e => e.AttributesName)
                    .HasMaxLength(50)
                    .HasColumnName("attributesName");

                entity.Property(e => e.AttributesValue)
                    .HasMaxLength(50)
                    .HasColumnName("attributesValue");

                entity.Property(e => e.BrandId).HasColumnName("brandId");

                entity.Property(e => e.BrandName)
                    .HasMaxLength(50)
                    .HasColumnName("brandName");

                entity.Property(e => e.CategoryId).HasColumnName("categoryId");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(200)
                    .HasColumnName("categoryName");

                entity.Property(e => e.FullName)
                    .HasMaxLength(300)
                    .HasColumnName("fullName");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Img)
                    .HasMaxLength(200)
                    .HasColumnName("img");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .HasColumnName("name");

                entity.Property(e => e.OnHand).HasColumnName("onHand");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.HasOne(d => d.Attributes)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.AttributesId)
                    .HasConstraintName("FK_product_attribute");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_product__brand");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_product_category");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.ToTable("supplier");

                entity.Property(e => e.SupplierId)
                    .HasMaxLength(10)
                    .HasColumnName("supplierId");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.ContactSup)
                    .HasMaxLength(15)
                    .HasColumnName("contactSup");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .HasColumnName("userId");

                entity.Property(e => e.PassWord)
                    .HasMaxLength(10)
                    .HasColumnName("passWord");

                entity.Property(e => e.Role)
                    .HasMaxLength(15)
                    .HasColumnName("role");

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .HasColumnName("userName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
