﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ThreadedProject2.Models;

#nullable disable

namespace ThreadedProject2.Migrations
{
    [DbContext(typeof(TravelExpertsContext))]
    partial class TravelExpertsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PackageProductsSupplier", b =>
                {
                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<int>("ProductSupplierId")
                        .HasColumnType("int");

                    b.HasKey("PackageId", "ProductSupplierId");

                    b.ToTable("PackageProductsSupplier");
                });

            modelBuilder.Entity("PackagesProductsSupplier", b =>
                {
                    b.Property<int>("PackageId")
                        .HasColumnType("int");

                    b.Property<int>("ProductSupplierId")
                        .HasColumnType("int");

                    b.HasKey("PackageId", "ProductSupplierId")
                        .HasName("aaaaaPackages_Products_Suppliers_PK");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("PackageId", "ProductSupplierId"), false);

                    b.HasIndex(new[] { "PackageId" }, "PackagesPackages_Products_Suppliers");

                    b.HasIndex(new[] { "ProductSupplierId" }, "ProductSupplierId");

                    b.HasIndex(new[] { "ProductSupplierId" }, "Products_SuppliersPackages_Products_Suppliers");

                    b.ToTable("Packages_Products_Suppliers", (string)null);
                });

            modelBuilder.Entity("ThreadedProject2.Models.Package", b =>
                {
                    b.Property<int>("PackageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PackageId"));

                    b.Property<decimal>("PkgAgencyCommission")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("money")
                        .HasDefaultValue(0m);

                    b.Property<decimal>("PkgBasePrice")
                        .HasColumnType("money");

                    b.Property<string>("PkgDesc")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PkgEndDate")
                        .HasColumnType("datetime");

                    b.Property<string>("PkgName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("PkgStartDate")
                        .HasColumnType("datetime");

                    b.HasKey("PackageId")
                        .HasName("aaaaaPackages_PK");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("PackageId"), false);

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("ThreadedProject2.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("ProdName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ProductId")
                        .HasName("aaaaaProducts_PK");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("ProductId"), false);

                    b.HasIndex(new[] { "ProductId" }, "ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ThreadedProject2.Models.ProductsSupplier", b =>
                {
                    b.Property<int>("ProductSupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductSupplierId"));

                    b.Property<int?>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<int?>("SupplierId")
                        .HasColumnType("int");

                    b.HasKey("ProductSupplierId")
                        .HasName("aaaaaProducts_Suppliers_PK");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("ProductSupplierId"), false);

                    b.HasIndex(new[] { "SupplierId" }, "Product Supplier ID");

                    b.HasIndex(new[] { "ProductId" }, "ProductId");

                    b.HasIndex(new[] { "ProductSupplierId" }, "ProductSupplierId");

                    b.HasIndex(new[] { "ProductId" }, "ProductsProducts_Suppliers1");

                    b.HasIndex(new[] { "SupplierId" }, "SuppliersProducts_Suppliers1");

                    b.ToTable("Products_Suppliers");
                });

            modelBuilder.Entity("ThreadedProject2.Models.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("SupName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("SupplierId")
                        .HasName("aaaaaSuppliers_PK");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("SupplierId"), false);

                    b.HasIndex(new[] { "SupplierId" }, "SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("ThreadedProject2.Models.SupplierContact", b =>
                {
                    b.Property<int>("SupplierContactId")
                        .HasColumnType("int");

                    b.Property<string>("AffiliationId")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("SupConAddress")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SupConBusPhone")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SupConCity")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SupConCompany")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SupConCountry")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SupConEmail")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SupConFax")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SupConFirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SupConLastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SupConPostal")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SupConProv")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("SupConUrl")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)")
                        .HasColumnName("SupConURL");

                    b.Property<int?>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.HasKey("SupplierContactId")
                        .HasName("aaaaaSupplierContacts_PK");

                    SqlServerKeyBuilderExtensions.IsClustered(b.HasKey("SupplierContactId"), false);

                    b.HasIndex(new[] { "AffiliationId" }, "AffiliationsSupCon");

                    b.HasIndex(new[] { "SupplierId" }, "SuppliersSupCon");

                    b.ToTable("SupplierContacts");
                });

            modelBuilder.Entity("PackagesProductsSupplier", b =>
                {
                    b.HasOne("ThreadedProject2.Models.Package", null)
                        .WithMany()
                        .HasForeignKey("PackageId")
                        .IsRequired()
                        .HasConstraintName("Packages_Products_Supplie_FK00");

                    b.HasOne("ThreadedProject2.Models.ProductsSupplier", null)
                        .WithMany()
                        .HasForeignKey("ProductSupplierId")
                        .IsRequired()
                        .HasConstraintName("Packages_Products_Supplie_FK01");
                });

            modelBuilder.Entity("ThreadedProject2.Models.ProductsSupplier", b =>
                {
                    b.HasOne("ThreadedProject2.Models.Product", "Product")
                        .WithMany("ProductsSuppliers")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("Products_Suppliers_FK00");

                    b.HasOne("ThreadedProject2.Models.Supplier", "Supplier")
                        .WithMany("ProductsSuppliers")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("Products_Suppliers_FK01");

                    b.Navigation("Product");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ThreadedProject2.Models.SupplierContact", b =>
                {
                    b.HasOne("ThreadedProject2.Models.Supplier", "Supplier")
                        .WithMany("SupplierContacts")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("SupplierContacts_FK01");

                    b.Navigation("Supplier");
                });

            modelBuilder.Entity("ThreadedProject2.Models.Product", b =>
                {
                    b.Navigation("ProductsSuppliers");
                });

            modelBuilder.Entity("ThreadedProject2.Models.Supplier", b =>
                {
                    b.Navigation("ProductsSuppliers");

                    b.Navigation("SupplierContacts");
                });
#pragma warning restore 612, 618
        }
    }
}
