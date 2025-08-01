﻿// <auto-generated />
using System;
using IISMSBackend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IISMSBackend.Migrations
{
    [DbContext(typeof(IISMSContext))]
    [Migration("20250415060013_ChangeRequired")]
    partial class ChangeRequired
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IISMSBackend.Entities.Inventory", b =>
                {
                    b.Property<int>("inventoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("inventoryId"));

                    b.Property<DateTime>("inventoryTimestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("operation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("productId")
                        .HasColumnType("integer");

                    b.Property<int>("quantity")
                        .HasColumnType("integer");

                    b.HasKey("inventoryId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("IISMSBackend.Entities.Product", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("productId"));

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("expirationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("firstCreationTimestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("price")
                        .HasColumnType("numeric");

                    b.Property<byte[]>("productBarcode")
                        .IsRequired()
                        .HasColumnType("bytea");

                    b.Property<byte[]>("productImage")
                        .HasColumnType("bytea");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("quantity")
                        .HasColumnType("bigint");

                    b.Property<decimal>("size")
                        .HasColumnType("numeric");

                    b.Property<string>("unit")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("productId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("IISMSBackend.Entities.Sales", b =>
                {
                    b.Property<int>("salesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("salesId"));

                    b.Property<DateTime>("salesTimestamp")
                        .HasColumnType("timestamp with time zone");

                    b.Property<decimal>("totalCartPrice")
                        .HasColumnType("numeric");

                    b.Property<int>("totalCartQuantity")
                        .HasColumnType("integer");

                    b.HasKey("salesId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("IISMSBackend.Entities.SalesProduct", b =>
                {
                    b.Property<int>("salesProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("salesProductId"));

                    b.Property<int>("productId")
                        .HasColumnType("integer");

                    b.Property<int>("salesId")
                        .HasColumnType("integer");

                    b.Property<int>("salesQuantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("totalUnitPrice")
                        .HasColumnType("numeric");

                    b.Property<decimal>("unitPrice")
                        .HasColumnType("numeric");

                    b.HasKey("salesProductId");

                    b.HasIndex("productId");

                    b.HasIndex("salesId");

                    b.ToTable("SalesProduct");
                });

            modelBuilder.Entity("IISMSBackend.Entities.User", b =>
                {
                    b.Property<int>("userId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("userId"));

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("fullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("phoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("userId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("IISMSBackend.Entities.SalesProduct", b =>
                {
                    b.HasOne("IISMSBackend.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IISMSBackend.Entities.Sales", "Sale")
                        .WithMany("SalesProducts")
                        .HasForeignKey("salesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Sale");
                });

            modelBuilder.Entity("IISMSBackend.Entities.Sales", b =>
                {
                    b.Navigation("SalesProducts");
                });
#pragma warning restore 612, 618
        }
    }
}
