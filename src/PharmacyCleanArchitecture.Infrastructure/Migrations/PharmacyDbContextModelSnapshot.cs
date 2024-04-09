﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PharmacyCleanArchitecture.Infrastructure.Common.Persistence;

#nullable disable

namespace PharmacyCleanArchitecture.Infrastructure.Migrations
{
    [DbContext(typeof(PharmacyDbContext))]
    partial class PharmacyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PharmacyCleanArchitecture.Domain.Brands.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("LogoImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("PharmacyCleanArchitecture.Domain.Categories.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PharmacyCleanArchitecture.Domain.OrderAggregate.Entities.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("PricePerUnit")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("PharmacyCleanArchitecture.Domain.OrderAggregate.Order", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DeliveredAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("PharmacyId")
                        .HasColumnType("uuid");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("User")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.ComplexProperty<Dictionary<string, object>>("ReceiverAddress", "PharmacyCleanArchitecture.Domain.OrderAggregate.Order.ReceiverAddress#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.HasIndex("PharmacyId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PharmacyCleanArchitecture.Domain.PharmacyAggregate.Entities.ProductInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<decimal?>("DiscountedPrice")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsInStock")
                        .HasColumnType("boolean");

                    b.Property<Guid>("PharmacyId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PharmacyId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductInfos");
                });

            modelBuilder.Entity("PharmacyCleanArchitecture.Domain.PharmacyAggregate.Pharmacy", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.ComplexProperty<Dictionary<string, object>>("Address", "PharmacyCleanArchitecture.Domain.PharmacyAggregate.Pharmacy.Address#Address", b1 =>
                        {
                            b1.IsRequired();

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("text");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("text");
                        });

                    b.HasKey("Id");

                    b.ToTable("Pharmacies");
                });

            modelBuilder.Entity("PharmacyCleanArchitecture.Domain.Products.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BrandId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Sku")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PharmacyCleanArchitecture.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PharmacyCleanArchitecture.Domain.OrderAggregate.Entities.OrderItem", b =>
                {
                    b.HasOne("PharmacyCleanArchitecture.Domain.OrderAggregate.Order", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("PharmacyCleanArchitecture.Domain.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PharmacyCleanArchitecture.Domain.OrderAggregate.Order", b =>
                {
                    b.HasOne("PharmacyCleanArchitecture.Domain.PharmacyAggregate.Pharmacy", "Pharmacy")
                        .WithMany("Orders")
                        .HasForeignKey("PharmacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("PharmacyCleanArchitecture.Domain.PharmacyAggregate.Entities.ProductInfo", b =>
                {
                    b.HasOne("PharmacyCleanArchitecture.Domain.PharmacyAggregate.Pharmacy", "Pharmacy")
                        .WithMany()
                        .HasForeignKey("PharmacyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyCleanArchitecture.Domain.Products.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pharmacy");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PharmacyCleanArchitecture.Domain.Products.Product", b =>
                {
                    b.HasOne("PharmacyCleanArchitecture.Domain.Brands.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PharmacyCleanArchitecture.Domain.Categories.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("PharmacyCleanArchitecture.Domain.OrderAggregate.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("PharmacyCleanArchitecture.Domain.PharmacyAggregate.Pharmacy", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
