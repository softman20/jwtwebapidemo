using IM.TCM.Domain.Configurations;
using IM.TCM.Domain.Models;
using IM.TCM.Domain.Models.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;

namespace IM.TCM.Data.EF
{
    public class TCMContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, IdentityUserClaim<int>, ApplicationUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public TCMContext(DbContextOptions<TCMContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserBusinessUnitConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyProcessTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountGroupProcessTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserAuthorizationConfiguration());
        }

        public override int SaveChanges()
        {
            var entityEntries = ChangeTracker.Entries().ToList();
            var added = entityEntries.Where(q => q.State == EntityState.Added).Select(q => q.Entity).OfType<BaseEntity>().ToList();
            var modified = entityEntries.Where(q => q.State == EntityState.Modified).Select(q => q.Entity).OfType<BaseEntity>().ToList();


            added.ForEach(a =>
            {
                a.CreatedDate = DateTime.UtcNow;
                a.IsActive = true;
            });
            modified.ForEach(a =>
            {
                a.UpdatedDate = DateTime.UtcNow;
            });
            return base.SaveChanges();
        }
        //  public DbSet<User> Users { get; set; }
        public DbSet<RefreshToken> RefreshToken { get; set; }
       // public DbSet<BusinessUnit> BusinessUnit { get; set; }

        public DbSet<UserBusinessUnit> UserBusinessUnit { get; set; }

        public DbSet<ProcessType> ProcessType { get; set; }
        public DbSet<Company> Company { get; set; }

        public DbSet<CompanyProcessType> CompanyProcessType { get;set;}
        public DbSet<AccountGroup> AccountGroup { get; set; }
        public DbSet<AccountGroupProcessType> AccountGroupProcessType { get; set; }

        public DbSet<UserAuthorization> UserAuthorization { get; set; }
    }
}
