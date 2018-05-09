using Domain.Configurations;
using Domain.Models;
using Domain.Models.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;

namespace Data.EF
{
    public class JWTDemoContext :  IdentityDbContext<ApplicationUser, ApplicationRole, int, IdentityUserClaim<int>, ApplicationUserRole, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public JWTDemoContext(DbContextOptions<JWTDemoContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RefreshTokenConfiguration());
            modelBuilder.ApplyConfiguration(new ApplicationUserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserBusinessUnitConfiguration());


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
        public DbSet<BusinessUnit> BusinessUnit { get; set; }

        public DbSet<UserBusinessUnit> UserBusinessUnit { get; set; }
    }
}
