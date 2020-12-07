﻿// <auto-generated />
using System;
using AgroPlan.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AgroPlan.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20201207132957_asd")]
    partial class asd
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AgroPlan.Core.Domain.Application", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationKindId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationKindId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.ApplicationKind", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ApplicationKinds");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.ChemicalElement", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ChemicalElements");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.ContentUnit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContentUnits");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Fertilization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DosePerHa")
                        .HasColumnType("float");

                    b.Property<Guid?>("FertilizerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FertilizerId");

                    b.ToTable("Fertilizations");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Fertilizer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fertilizers");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.FertilizerComponent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ChemicalElementId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FertilizerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PercentageContent")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChemicalElementId");

                    b.HasIndex("FertilizerId");

                    b.ToTable("FertilizerComponents");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Field", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Fields");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.MostCommonlyGrownPlant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PlantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("PlantId");

                    b.HasIndex("UserId");

                    b.ToTable("MostCommonlyGrownPlants");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Parcel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CultivatedArea")
                        .HasColumnType("int");

                    b.Property<Guid?>("FieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.ToTable("Parcels");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.ParcelApplication", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ParcelId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("ParcelId");

                    b.ToTable("ParcelApplications");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.ParcelCoveredByTreatment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ParcelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TreatmentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ParcelId");

                    b.HasIndex("TreatmentId");

                    b.ToTable("ParcelCoveredByTreatments");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Plant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("EfaNitrogenRate")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Plants");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Season", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EndYear")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StartYear")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Sowing", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("DosePerHa")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Sowings");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Spraying", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReasonForUse")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sprayings");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.SprayingComponent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Content")
                        .HasColumnType("float");

                    b.Property<Guid?>("ContentUnitId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SprayingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SprayingProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ContentUnitId");

                    b.HasIndex("SprayingId");

                    b.HasIndex("SprayingProductId");

                    b.ToTable("SprayingComponents");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.SprayingProduct", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SprayingProducts");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Treatment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("FertilizationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParcelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SowingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SprayingId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("TreatmentKindId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FertilizationId");

                    b.HasIndex("ParcelId");

                    b.HasIndex("SowingId");

                    b.HasIndex("SprayingId");

                    b.HasIndex("TreatmentKindId");

                    b.ToTable("Treatments");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.TreatmentKind", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TreatmentKinds");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.YearPlan", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FieldId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PlantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SeasonId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.HasIndex("PlantId");

                    b.HasIndex("SeasonId");

                    b.ToTable("YearPlans");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Application", b =>
                {
                    b.HasOne("AgroPlan.Core.Domain.ApplicationKind", "ApplicationKind")
                        .WithMany()
                        .HasForeignKey("ApplicationKindId");

                    b.HasOne("AgroPlan.Core.Domain.Season", "Season")
                        .WithMany("Applications")
                        .HasForeignKey("SeasonId");

                    b.Navigation("ApplicationKind");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Fertilization", b =>
                {
                    b.HasOne("AgroPlan.Core.Domain.Fertilizer", "Fertilizer")
                        .WithMany()
                        .HasForeignKey("FertilizerId");

                    b.Navigation("Fertilizer");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.FertilizerComponent", b =>
                {
                    b.HasOne("AgroPlan.Core.Domain.ChemicalElement", "ChemicalElement")
                        .WithMany()
                        .HasForeignKey("ChemicalElementId");

                    b.HasOne("AgroPlan.Core.Domain.Fertilizer", "Fertilizer")
                        .WithMany("FertilizerComponents")
                        .HasForeignKey("FertilizerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("ChemicalElement");

                    b.Navigation("Fertilizer");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Field", b =>
                {
                    b.HasOne("AgroPlan.Core.Domain.ApplicationUser", "User")
                        .WithMany("Fields")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.MostCommonlyGrownPlant", b =>
                {
                    b.HasOne("AgroPlan.Core.Domain.Plant", "Plant")
                        .WithMany()
                        .HasForeignKey("PlantId");

                    b.HasOne("AgroPlan.Core.Domain.ApplicationUser", "User")
                        .WithMany("MostCommonlyGrownPlants")
                        .HasForeignKey("UserId");

                    b.Navigation("Plant");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Parcel", b =>
                {
                    b.HasOne("AgroPlan.Core.Domain.Field", "Field")
                        .WithMany("Parcels")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Field");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.ParcelApplication", b =>
                {
                    b.HasOne("AgroPlan.Core.Domain.Application", "Application")
                        .WithMany("ParcelApplications")
                        .HasForeignKey("ApplicationId");

                    b.HasOne("AgroPlan.Core.Domain.Parcel", "Parcel")
                        .WithMany()
                        .HasForeignKey("ParcelId");

                    b.Navigation("Application");

                    b.Navigation("Parcel");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.ParcelCoveredByTreatment", b =>
                {
                    b.HasOne("AgroPlan.Core.Domain.Parcel", "Parcel")
                        .WithMany()
                        .HasForeignKey("ParcelId");

                    b.HasOne("AgroPlan.Core.Domain.Treatment", "Treatment")
                        .WithMany("ParcelCoveredByTreatments")
                        .HasForeignKey("TreatmentId");

                    b.Navigation("Parcel");

                    b.Navigation("Treatment");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Season", b =>
                {
                    b.HasOne("AgroPlan.Core.Domain.ApplicationUser", "User")
                        .WithMany("Seasons")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.SprayingComponent", b =>
                {
                    b.HasOne("AgroPlan.Core.Domain.ContentUnit", "ContentUnit")
                        .WithMany()
                        .HasForeignKey("ContentUnitId");

                    b.HasOne("AgroPlan.Core.Domain.Spraying", "Spraying")
                        .WithMany("SprayingComponents")
                        .HasForeignKey("SprayingId");

                    b.HasOne("AgroPlan.Core.Domain.SprayingProduct", "SprayingProduct")
                        .WithMany()
                        .HasForeignKey("SprayingProductId");

                    b.Navigation("ContentUnit");

                    b.Navigation("Spraying");

                    b.Navigation("SprayingProduct");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Treatment", b =>
                {
                    b.HasOne("AgroPlan.Core.Domain.Fertilization", "Fertilization")
                        .WithMany()
                        .HasForeignKey("FertilizationId");

                    b.HasOne("AgroPlan.Core.Domain.Parcel", null)
                        .WithMany("Treatments")
                        .HasForeignKey("ParcelId");

                    b.HasOne("AgroPlan.Core.Domain.Sowing", "Sowing")
                        .WithMany()
                        .HasForeignKey("SowingId");

                    b.HasOne("AgroPlan.Core.Domain.Spraying", "Spraying")
                        .WithMany()
                        .HasForeignKey("SprayingId");

                    b.HasOne("AgroPlan.Core.Domain.TreatmentKind", "TreatmentKind")
                        .WithMany()
                        .HasForeignKey("TreatmentKindId");

                    b.Navigation("Fertilization");

                    b.Navigation("Sowing");

                    b.Navigation("Spraying");

                    b.Navigation("TreatmentKind");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.YearPlan", b =>
                {
                    b.HasOne("AgroPlan.Core.Domain.Field", "Field")
                        .WithMany("YearPlans")
                        .HasForeignKey("FieldId");

                    b.HasOne("AgroPlan.Core.Domain.Plant", "Plant")
                        .WithMany()
                        .HasForeignKey("PlantId");

                    b.HasOne("AgroPlan.Core.Domain.Season", "Season")
                        .WithMany()
                        .HasForeignKey("SeasonId");

                    b.Navigation("Field");

                    b.Navigation("Plant");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("AgroPlan.Core.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("AgroPlan.Core.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AgroPlan.Core.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("AgroPlan.Core.Domain.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Application", b =>
                {
                    b.Navigation("ParcelApplications");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.ApplicationUser", b =>
                {
                    b.Navigation("Fields");

                    b.Navigation("MostCommonlyGrownPlants");

                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Fertilizer", b =>
                {
                    b.Navigation("FertilizerComponents");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Field", b =>
                {
                    b.Navigation("Parcels");

                    b.Navigation("YearPlans");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Parcel", b =>
                {
                    b.Navigation("Treatments");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Season", b =>
                {
                    b.Navigation("Applications");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Spraying", b =>
                {
                    b.Navigation("SprayingComponents");
                });

            modelBuilder.Entity("AgroPlan.Core.Domain.Treatment", b =>
                {
                    b.Navigation("ParcelCoveredByTreatments");
                });
#pragma warning restore 612, 618
        }
    }
}