﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesEstimate.Data;

#nullable disable

namespace SalesEstimate.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SalesEstimate.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
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

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .IsRequired()
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

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("SalesEstimate.Models.LookupType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LookupTypes");
                });

            modelBuilder.Entity("SalesEstimate.Models.LookupValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CustomField1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CustomField2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("CustomField3")
                        .HasColumnType("real");

                    b.Property<float?>("CustomField4")
                        .HasColumnType("real");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("LookupTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LookupTypeId");

                    b.ToTable("LookupValues");
                });

            modelBuilder.Entity("SalesEstimate.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("ContactFax")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ContactPhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Contractor")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerPurchaseOrder")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Express")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("Fastlane")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool?>("IsActivatePriceCalculation")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsBuyAmericaActProject")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsPurchaseOrderQuoted")
                        .HasColumnType("bit");

                    b.Property<string>("JobSiteContactName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("JobSiteContactPhone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("JobSiteName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("LookupStateId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("OrderType")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ParentOrderId")
                        .HasColumnType("int");

                    b.Property<decimal?>("ProjectTotalValue")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("QuotationRequest")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("QuoteNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("RequiredDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("RevisionNumber")
                        .HasColumnType("int");

                    b.Property<string>("ShipToAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal?>("Standard")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StreetAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal?>("Turbo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ZipCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("LookupStateId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("SalesEstimate.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ElevationDrawing")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FrameQty")
                        .HasColumnType("int");

                    b.Property<decimal>("Head")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("HeightFeet")
                        .HasColumnType("int");

                    b.Property<decimal>("HeightInches")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("HingeJamb")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("JambDepth")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("LookupAdditionalAnchorsId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupAdditionalStrikeId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupAdditionaloptionOnHingeId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupAnchorsId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupAssemblyId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupCloserId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupFinishId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupFireLabelId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupGaugeId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupHandingId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupHandingTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupHardwareLocationId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupHeadPrepId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupHingesId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupOptions1Id")
                        .HasColumnType("int");

                    b.Property<int?>("LookupOptions2Id")
                        .HasColumnType("int");

                    b.Property<int?>("LookupOptions3Id")
                        .HasColumnType("int");

                    b.Property<int?>("LookupOtherThanDoorId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupProfileId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupProfileOptionId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupReturnId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupSeriesId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupSteelMaterialId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupStrikeId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("LookupXifPairId")
                        .HasColumnType("int");

                    b.Property<string>("ModifiedBy")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("QTY")
                        .HasColumnType("int");

                    b.Property<decimal>("StrikeJamb")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("UnequalPairWidthFeet")
                        .HasColumnType("int");

                    b.Property<decimal>("UnequalPairWidthInches")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("WidthFeet")
                        .HasColumnType("int");

                    b.Property<decimal>("WidthInches")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("LookupAdditionalAnchorsId");

                    b.HasIndex("LookupAdditionalStrikeId");

                    b.HasIndex("LookupAdditionaloptionOnHingeId");

                    b.HasIndex("LookupAnchorsId");

                    b.HasIndex("LookupAssemblyId");

                    b.HasIndex("LookupCloserId");

                    b.HasIndex("LookupFinishId");

                    b.HasIndex("LookupFireLabelId");

                    b.HasIndex("LookupGaugeId");

                    b.HasIndex("LookupHandingTypeId");

                    b.HasIndex("LookupHardwareLocationId");

                    b.HasIndex("LookupHeadPrepId");

                    b.HasIndex("LookupHingesId");

                    b.HasIndex("LookupOptions1Id");

                    b.HasIndex("LookupOptions2Id");

                    b.HasIndex("LookupOptions3Id");

                    b.HasIndex("LookupOtherThanDoorId");

                    b.HasIndex("LookupProfileId");

                    b.HasIndex("LookupProfileOptionId");

                    b.HasIndex("LookupReturnId");

                    b.HasIndex("LookupSeriesId");

                    b.HasIndex("LookupSteelMaterialId");

                    b.HasIndex("LookupStrikeId");

                    b.HasIndex("LookupTypeId");

                    b.HasIndex("LookupXifPairId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SalesEstimate.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SalesEstimate.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SalesEstimate.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SalesEstimate.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SalesEstimate.Models.LookupValue", b =>
                {
                    b.HasOne("SalesEstimate.Models.LookupType", "LookupType")
                        .WithMany()
                        .HasForeignKey("LookupTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LookupType");
                });

            modelBuilder.Entity("SalesEstimate.Models.Order", b =>
                {
                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupState")
                        .WithMany()
                        .HasForeignKey("LookupStateId");

                    b.Navigation("LookupState");
                });

            modelBuilder.Entity("SalesEstimate.Models.OrderDetail", b =>
                {
                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupAdditionalAnchors")
                        .WithMany()
                        .HasForeignKey("LookupAdditionalAnchorsId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupAdditionalStrike")
                        .WithMany()
                        .HasForeignKey("LookupAdditionalStrikeId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupAdditionaloptionOnHinge")
                        .WithMany()
                        .HasForeignKey("LookupAdditionaloptionOnHingeId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupAnchors")
                        .WithMany()
                        .HasForeignKey("LookupAnchorsId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupAssembly")
                        .WithMany()
                        .HasForeignKey("LookupAssemblyId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupCloser")
                        .WithMany()
                        .HasForeignKey("LookupCloserId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupFinish")
                        .WithMany()
                        .HasForeignKey("LookupFinishId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupFireLabel")
                        .WithMany()
                        .HasForeignKey("LookupFireLabelId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupGauge")
                        .WithMany()
                        .HasForeignKey("LookupGaugeId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupHandingType")
                        .WithMany()
                        .HasForeignKey("LookupHandingTypeId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupHardwareLocation")
                        .WithMany()
                        .HasForeignKey("LookupHardwareLocationId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupHeadPrep")
                        .WithMany()
                        .HasForeignKey("LookupHeadPrepId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupHinges")
                        .WithMany()
                        .HasForeignKey("LookupHingesId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupOptions1")
                        .WithMany()
                        .HasForeignKey("LookupOptions1Id");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupOptions2")
                        .WithMany()
                        .HasForeignKey("LookupOptions2Id");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupOptions3")
                        .WithMany()
                        .HasForeignKey("LookupOptions3Id");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupOtherThanDoor")
                        .WithMany()
                        .HasForeignKey("LookupOtherThanDoorId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupProfile")
                        .WithMany()
                        .HasForeignKey("LookupProfileId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupProfileOption")
                        .WithMany()
                        .HasForeignKey("LookupProfileOptionId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupReturn")
                        .WithMany()
                        .HasForeignKey("LookupReturnId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupSeries")
                        .WithMany()
                        .HasForeignKey("LookupSeriesId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupSteelMaterial")
                        .WithMany()
                        .HasForeignKey("LookupSteelMaterialId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupStrike")
                        .WithMany()
                        .HasForeignKey("LookupStrikeId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupType")
                        .WithMany()
                        .HasForeignKey("LookupTypeId");

                    b.HasOne("SalesEstimate.Models.LookupValue", "LookupXifPair")
                        .WithMany()
                        .HasForeignKey("LookupXifPairId");

                    b.HasOne("SalesEstimate.Models.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LookupAdditionalAnchors");

                    b.Navigation("LookupAdditionalStrike");

                    b.Navigation("LookupAdditionaloptionOnHinge");

                    b.Navigation("LookupAnchors");

                    b.Navigation("LookupAssembly");

                    b.Navigation("LookupCloser");

                    b.Navigation("LookupFinish");

                    b.Navigation("LookupFireLabel");

                    b.Navigation("LookupGauge");

                    b.Navigation("LookupHandingType");

                    b.Navigation("LookupHardwareLocation");

                    b.Navigation("LookupHeadPrep");

                    b.Navigation("LookupHinges");

                    b.Navigation("LookupOptions1");

                    b.Navigation("LookupOptions2");

                    b.Navigation("LookupOptions3");

                    b.Navigation("LookupOtherThanDoor");

                    b.Navigation("LookupProfile");

                    b.Navigation("LookupProfileOption");

                    b.Navigation("LookupReturn");

                    b.Navigation("LookupSeries");

                    b.Navigation("LookupSteelMaterial");

                    b.Navigation("LookupStrike");

                    b.Navigation("LookupType");

                    b.Navigation("LookupXifPair");

                    b.Navigation("Order");
                });
#pragma warning restore 612, 618
        }
    }
}
