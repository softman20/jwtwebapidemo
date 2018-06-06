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
    partial class TCMContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<DateTime?>("CreatedDate");

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

                    b.Property<string>("Gender");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsSuperAdmin");

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

                    b.Property<bool>("ValidAvatar");

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

                    b.Property<string>("Name");

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

                    b.Property<DateTime?>("CreatedDate");

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
                    b.Property<int>("Id");

                    b.Property<string>("Name");

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

            modelBuilder.Entity("IM.TCM.Domain.Models.RequestType", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("RequestType");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.SalesOrganization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BusinessUnitId");

                    b.Property<string>("Code");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Name");

                    b.Property<int>("ProcessTypeId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("BusinessUnitId");

                    b.HasIndex("ProcessTypeId");

                    b.ToTable("SalesOrganization");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.Template", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountGroupId");

                    b.Property<int>("BUId");

                    b.Property<int>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<int>("OrganizationId");

                    b.Property<int>("ProcessTypeId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("AccountGroupId");

                    b.HasIndex("BUId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("ProcessTypeId");

                    b.ToTable("Template");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.TemplateControl", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BUId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<string>("Label");

                    b.Property<int>("ProcessTypeId");

                    b.Property<string>("SapField");

                    b.Property<string>("SapTable");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("BUId");

                    b.HasIndex("ProcessTypeId");

                    b.ToTable("TemplateControl");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.TemplateControlConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("AlterableApprover1");

                    b.Property<bool>("AlterableApprover2");

                    b.Property<bool>("AlterableApprover3");

                    b.Property<bool>("AlterableProvider");

                    b.Property<bool>("Capital");

                    b.Property<string>("DefaultValue");

                    b.Property<bool>("Display");

                    b.Property<bool>("Mandatory");

                    b.Property<int>("TemplateControlId");

                    b.Property<int>("TemplateId");

                    b.HasKey("Id");

                    b.HasIndex("TemplateControlId");

                    b.HasIndex("TemplateId");

                    b.ToTable("TemplateControlConfig");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.UserAuthorization", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("BUId");

                    b.Property<int>("CompanyId");

                    b.Property<int>("RoleId");

                    b.Property<int>("ProcessTypeId");

                    b.Property<int>("OrganizationId");

                    b.HasKey("UserId", "BUId", "CompanyId", "RoleId", "ProcessTypeId", "OrganizationId");

                    b.HasIndex("BUId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("ProcessTypeId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserAuthorization");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.UserBusinessUnit", b =>
                {
                    b.Property<int>("UserId");

                    b.Property<int>("BUId");

                    b.HasKey("UserId", "BUId");

                    b.HasIndex("BUId");

                    b.ToTable("UserBusinessUnit");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.ValidationRule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccountGroupId");

                    b.Property<int>("BUId");

                    b.Property<int>("CompanyId");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<int>("OrganizationId");

                    b.Property<int>("ProcessTypeId");

                    b.Property<int>("RequestTypeId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.HasKey("Id");

                    b.HasIndex("AccountGroupId");

                    b.HasIndex("BUId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("OrganizationId");

                    b.HasIndex("ProcessTypeId");

                    b.HasIndex("RequestTypeId");

                    b.ToTable("ValidationRule");
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.ValidationRuleUserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("CreatedDate");

                    b.Property<bool>("IsActive");

                    b.Property<int>("RoleId");

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedDate");

                    b.Property<int>("UserId");

                    b.Property<int>("ValidationRuleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.HasIndex("ValidationRuleId");

                    b.ToTable("ValidationRuleUserRole");
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

            modelBuilder.Entity("IM.TCM.Domain.Models.SalesOrganization", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.BusinessUnit", "BusinessUnit")
                        .WithMany()
                        .HasForeignKey("BusinessUnitId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IM.TCM.Domain.Models.ProcessType", "ProcessType")
                        .WithMany()
                        .HasForeignKey("ProcessTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.Template", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.AccountGroup", "AccountGroup")
                        .WithMany("Templates")
                        .HasForeignKey("AccountGroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IM.TCM.Domain.Models.BusinessUnit", "BusinessUnit")
                        .WithMany("Templates")
                        .HasForeignKey("BUId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IM.TCM.Domain.Models.Company", "CompanyCode")
                        .WithMany("Templates")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IM.TCM.Domain.Models.SalesOrganization", "Organization")
                        .WithMany("Templates")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IM.TCM.Domain.Models.ProcessType", "ProcessType")
                        .WithMany("Templates")
                        .HasForeignKey("ProcessTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.TemplateControl", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.BusinessUnit", "BusinessUnit")
                        .WithMany()
                        .HasForeignKey("BUId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IM.TCM.Domain.Models.ProcessType", "ProcessType")
                        .WithMany()
                        .HasForeignKey("ProcessTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.TemplateControlConfig", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.TemplateControl", "TemplateControl")
                        .WithMany()
                        .HasForeignKey("TemplateControlId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IM.TCM.Domain.Models.Template", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.UserAuthorization", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.BusinessUnit", "BusinessUnit")
                        .WithMany("UserAuthorizations")
                        .HasForeignKey("BUId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IM.TCM.Domain.Models.Company", "CompanyCode")
                        .WithMany("UserAuthorizations")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IM.TCM.Domain.Models.SalesOrganization", "Organization")
                        .WithMany("UserAuthorizations")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IM.TCM.Domain.Models.ProcessType", "ProcessType")
                        .WithMany("UserAuthorizations")
                        .HasForeignKey("ProcessTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IM.TCM.Domain.Models.ApplicationRole", "Role")
                        .WithMany("UserAuthorizations")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IM.TCM.Domain.Models.ApplicationUser", "User")
                        .WithMany("Authorizations")
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

            modelBuilder.Entity("IM.TCM.Domain.Models.ValidationRule", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.AccountGroup", "AccountGroup")
                        .WithMany("ValidationRules")
                        .HasForeignKey("AccountGroupId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IM.TCM.Domain.Models.BusinessUnit", "BusinessUnit")
                        .WithMany("ValidationRules")
                        .HasForeignKey("BUId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IM.TCM.Domain.Models.Company", "CompanyCode")
                        .WithMany("ValidationRules")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IM.TCM.Domain.Models.SalesOrganization", "Organization")
                        .WithMany("ValidationRules")
                        .HasForeignKey("OrganizationId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IM.TCM.Domain.Models.ProcessType", "ProcessType")
                        .WithMany("ValidationRules")
                        .HasForeignKey("ProcessTypeId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("IM.TCM.Domain.Models.RequestType", "RequestType")
                        .WithMany("ValidationRules")
                        .HasForeignKey("RequestTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("IM.TCM.Domain.Models.ValidationRuleUserRole", b =>
                {
                    b.HasOne("IM.TCM.Domain.Models.ApplicationRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IM.TCM.Domain.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("IM.TCM.Domain.Models.ValidationRule", "ValidationRule")
                        .WithMany()
                        .HasForeignKey("ValidationRuleId")
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
