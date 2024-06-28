﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RevenueRecognition.Data;

#nullable disable

namespace RevenueRecognition.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240628212020_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RevenueRecognition.Models.Domain.AppUser", b =>
                {
                    b.Property<int>("IdUser")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUser"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExp")
                        .HasColumnType("datetime2");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("IdUser");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("RevenueRecognition.Models.Domain.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ClientType")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsDeleted")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("ClientId");

                    b.ToTable("Client");

                    b.HasDiscriminator<string>("ClientType").HasValue("Client");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("RevenueRecognition.Models.Domain.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContractId"));

                    b.Property<DateTime>("AdditionalSupportEndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ContractEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ContractStartDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DiscountId")
                        .HasColumnType("int");

                    b.Property<bool>("IsSigned")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PaymentEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PaymentStartDate")
                        .HasColumnType("datetime2");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("SoftwareId")
                        .HasColumnType("int");

                    b.HasKey("ContractId");

                    b.HasIndex("ClientId");

                    b.HasIndex("DiscountId");

                    b.HasIndex("SoftwareId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("RevenueRecognition.Models.Domain.Discount", b =>
                {
                    b.Property<int>("DiscountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DiscountId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("DiscountValue")
                        .HasColumnType("real");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DiscountId");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("RevenueRecognition.Models.Domain.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"));

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFinalPayment")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PaymentId");

                    b.HasIndex("ContractId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("RevenueRecognition.Models.Domain.SoftwareLicense", b =>
                {
                    b.Property<int>("SoftwareId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SoftwareId"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("SoftwareId");

                    b.ToTable("SoftwareLicenses");
                });

            modelBuilder.Entity("RevenueRecognition.Models.Domain.SoftwareVersion", b =>
                {
                    b.Property<int>("SoftwareLicenseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ReleaseNotes")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("SoftwareVersionId")
                        .HasColumnType("int");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("SoftwareLicenseId");

                    b.ToTable("SoftwareVersions");
                });

            modelBuilder.Entity("RevenueRecognition.Models.Domain.CompanyClient", b =>
                {
                    b.HasBaseType("RevenueRecognition.Models.Domain.Client");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("KRS")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasDiscriminator().HasValue("Company");
                });

            modelBuilder.Entity("RevenueRecognition.Models.Domain.IndividualClient", b =>
                {
                    b.HasBaseType("RevenueRecognition.Models.Domain.Client");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PESEL")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.HasDiscriminator().HasValue("Individual");
                });

            modelBuilder.Entity("RevenueRecognition.Models.Domain.Contract", b =>
                {
                    b.HasOne("RevenueRecognition.Models.Domain.Client", "Client")
                        .WithMany("Contracts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RevenueRecognition.Models.Domain.Discount", "Discount")
                        .WithMany("Contracts")
                        .HasForeignKey("DiscountId");

                    b.HasOne("RevenueRecognition.Models.Domain.SoftwareLicense", "SoftwareLicense")
                        .WithMany("Contracts")
                        .HasForeignKey("SoftwareId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Discount");

                    b.Navigation("SoftwareLicense");
                });

            modelBuilder.Entity("RevenueRecognition.Models.Domain.Payment", b =>
                {
                    b.HasOne("RevenueRecognition.Models.Domain.Contract", "Contract")
                        .WithMany("Payments")
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contract");
                });

            modelBuilder.Entity("RevenueRecognition.Models.Domain.SoftwareVersion", b =>
                {
                    b.HasOne("RevenueRecognition.Models.Domain.SoftwareLicense", "SoftwareLicense")
                        .WithMany("SoftwareVersions")
                        .HasForeignKey("SoftwareLicenseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SoftwareLicense");
                });

            modelBuilder.Entity("RevenueRecognition.Models.Domain.Client", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("RevenueRecognition.Models.Domain.Contract", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("RevenueRecognition.Models.Domain.Discount", b =>
                {
                    b.Navigation("Contracts");
                });

            modelBuilder.Entity("RevenueRecognition.Models.Domain.SoftwareLicense", b =>
                {
                    b.Navigation("Contracts");

                    b.Navigation("SoftwareVersions");
                });
#pragma warning restore 612, 618
        }
    }
}
