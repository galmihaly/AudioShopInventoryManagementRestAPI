﻿// <auto-generated />
using System;
using DemoRestAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AudioShopInventoryManagementRestAPI.Migrations
{
    [DbContext(typeof(SqlDBContext))]
    partial class SqlDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DemoRestAPI.Brands.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BrandId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Owner")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("DemoRestAPI.Categories.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DemoRestAPI.Devices.Device", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DeviceId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("DemoRestAPI.Models.Model", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ModelId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Models");
                });

            modelBuilder.Entity("DemoRestAPI.Products.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("BasePrice")
                        .HasColumnType("int");

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ModelId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProductId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("StorageId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WholeSalePrice")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ModelId");

                    b.HasIndex("StorageId");

                    b.HasIndex("UserId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DemoRestAPI.Storages.Storage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BruttoValue")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("MaxQuantity")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("NettoValue")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<string>("StorageId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WareHouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WareHouseId");

                    b.ToTable("Storages");
                });

            modelBuilder.Entity("DemoRestAPI.Users.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool?>("Active")
                        .IsRequired()
                        .HasColumnType("bit")
                        .HasAnnotation("Relational:JsonPropertyName", "active");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "address");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "created_at");

                    b.Property<int?>("DeviceId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "modified_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "name");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "refreshtoken");

                    b.Property<DateTime>("RefreshTokenExpiration")
                        .HasColumnType("datetime2")
                        .HasAnnotation("Relational:JsonPropertyName", "refreshtoken_expiration");

                    b.Property<string>("Right")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasAnnotation("Relational:JsonPropertyName", "right");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("WareHouseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DeviceId")
                        .IsUnique()
                        .HasFilter("[DeviceId] IS NOT NULL");

                    b.HasIndex("WareHouseId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DemoRestAPI.Warehouses.Warehouse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BruttoValue")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CurrentStockCapacity")
                        .HasColumnType("int");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NettoValue")
                        .HasColumnType("int");

                    b.Property<int?>("StockMaxCapacity")
                        .HasColumnType("int");

                    b.Property<string>("WareHouseId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Warehouses");
                });

            modelBuilder.Entity("DemoRestAPI.Products.Product", b =>
                {
                    b.HasOne("DemoRestAPI.Brands.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId");

                    b.HasOne("DemoRestAPI.Categories.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("DemoRestAPI.Models.Model", "Model")
                        .WithMany("Products")
                        .HasForeignKey("ModelId");

                    b.HasOne("DemoRestAPI.Storages.Storage", "Storage")
                        .WithMany("Products")
                        .HasForeignKey("StorageId");

                    b.HasOne("DemoRestAPI.Users.User", "User")
                        .WithMany("Products")
                        .HasForeignKey("UserId");

                    b.Navigation("Brand");

                    b.Navigation("Category");

                    b.Navigation("Model");

                    b.Navigation("Storage");

                    b.Navigation("User");
                });

            modelBuilder.Entity("DemoRestAPI.Storages.Storage", b =>
                {
                    b.HasOne("DemoRestAPI.Warehouses.Warehouse", "Warehouse")
                        .WithMany("Storages")
                        .HasForeignKey("WareHouseId");

                    b.Navigation("Warehouse");
                });

            modelBuilder.Entity("DemoRestAPI.Users.User", b =>
                {
                    b.HasOne("DemoRestAPI.Devices.Device", "Device")
                        .WithOne("User")
                        .HasForeignKey("DemoRestAPI.Users.User", "DeviceId");

                    b.HasOne("DemoRestAPI.Warehouses.Warehouse", "WareHouse")
                        .WithMany("Users")
                        .HasForeignKey("WareHouseId");

                    b.Navigation("Device");

                    b.Navigation("WareHouse");
                });

            modelBuilder.Entity("DemoRestAPI.Brands.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DemoRestAPI.Categories.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DemoRestAPI.Devices.Device", b =>
                {
                    b.Navigation("User");
                });

            modelBuilder.Entity("DemoRestAPI.Models.Model", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DemoRestAPI.Storages.Storage", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DemoRestAPI.Users.User", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("DemoRestAPI.Warehouses.Warehouse", b =>
                {
                    b.Navigation("Storages");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
