using IM.TCM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Configurations
{
    public class UserAuthorizationConfiguration : IEntityTypeConfiguration<UserAuthorization>
    {
        public void Configure(EntityTypeBuilder<UserAuthorization> builder)
        {
            builder.HasKey(ub => new { ub.UserId, ub.BUId,ub.CompanyId,ub.RoleId,ub.ProcessTypeId,ub.OrganizationId });

            builder.HasOne(pt => pt.User).WithMany(t => t.Authorizations).HasForeignKey(p => p.UserId);
            builder.HasOne(pt => pt.BusinessUnit).WithMany(t => t.UserAuthorizations).HasForeignKey(pt => pt.BUId);
            builder.HasOne(pt => pt.CompanyCode).WithMany(t => t.UserAuthorizations).HasForeignKey(pt => pt.CompanyId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(pt => pt.Role).WithMany(t => t.UserAuthorizations).HasForeignKey(pt => pt.RoleId);
            builder.HasOne(pt => pt.ProcessType).WithMany(t => t.UserAuthorizations).HasForeignKey(pt => pt.ProcessTypeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(pt => pt.Organization).WithMany(t => t.UserAuthorizations).HasForeignKey(pt => pt.OrganizationId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
