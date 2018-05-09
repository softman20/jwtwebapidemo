using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configurations
{
    public class UserBusinessUnitConfiguration : IEntityTypeConfiguration<UserBusinessUnit>
    {
        public void Configure(EntityTypeBuilder<UserBusinessUnit> builder)
        {
            builder.HasKey(ub => new { ub.UserId, ub.BUId });
            builder.HasOne(pt => pt.User).WithMany(t => t.UserBusinessUnits).HasForeignKey(p => p.UserId);
            builder.HasOne(pt => pt.BusinessUnit).WithMany(t => t.UserBusinessUnits).HasForeignKey(pt => pt.BUId);
            
        }
    }
}
