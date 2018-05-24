﻿// <auto-generated />
using IM.TCM.Data.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace IM.TCM.Data.Migrations
{
    [DbContext(typeof(TCMContext))]
    [Migration("20180516163113_AccountGroup")]
    partial class AccountGroup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IM.TCM.Domain.Models.AccountGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BusinessUnitId");

                    b.Property<string>("Code");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("BusinessUnitId");

                    b.ToTable("AccountGroup");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.AccountGroupProcessType", b =>
                {
                    b.Property<int>("AccountGroupId");

                    b.Property<int>("ProcessTypeId");

                    b.HasKey("AccountGroupId", "ProcessTypeId");

                    b.HasIndex("ProcessTypeId");

                    b.ToTable("AccountGroupProcessType");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<bool>("IsActive");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("SgId")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.ApplicationUserRole", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.BusinessUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("BusinessUnit");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BusinessUnitId");

                    b.Property<string>("Code");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("BusinessUnitId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.CompanyProcessType", b =>
                {
                    b.Property<int>("CompanyId");

                    b.Property<int>("ProcessTypeId");

                    b.HasKey("CompanyId", "ProcessTypeId");

                    b.HasIndex("ProcessTypeId");

                    b.ToTable("CompanyProcessType");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.ProcessType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.ToTable("ProcessType");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("ExpiresUtc");

                    b.Property<DateTime>("IssuedUtc");

                    b.Property<string>("Token")
                        .IsRequired();

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasAlternateKey("Token");


                    b.HasAlternateKey("UserId");

                    b.ToTable("RefreshToken");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.UserBusinessUnit", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("BUId");

                    b.HasKey("UserId", "BUId");

                    b.HasIndex("BUId");

                    b.ToTable("UserBusinessUnit");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<int>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.AccountGroup", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.BusinessUnit", "BusinessUnit")
                        .WithMany()
                        .HasForeignKey("BusinessUnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.AccountGroupProcessType", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.AccountGroup", "AccountGroup")
                        .WithMany("AccountGroupProcessType")
                        .HasForeignKey("AccountGroupId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IM.TCM.Domain.Models.ProcessType", "ProcessType")
                        .WithMany("AccountGroupProcessType")
                        .HasForeignKey("ProcessTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.ApplicationUserRole", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.ApplicationRole", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IM.TCM.Domain.Models.ApplicationUser", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.Company", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.BusinessUnit", "BusinessUnit")
                        .WithMany()
                        .HasForeignKey("BusinessUnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.CompanyProcessType", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.Company", "Company")
                        .WithMany("CompanyProcessTypes")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IM.TCM.Domain.Models.ProcessType", "ProcessType")
                        .WithMany("CompanyProcessTypes")
                        .HasForeignKey("ProcessTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.RefreshToken", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.UserBusinessUnit", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.BusinessUnit", "BusinessUnit")
                        .WithMany("UserBusinessUnits")
                        .HasForeignKey("BUId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IM.TCM.Domain.Models.ApplicationUser", "User")
                        .WithMany("UserBusinessUnits")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
