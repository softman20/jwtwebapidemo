using IM.TCM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Configurations
{
    public class ApplicationUserRoleConfiguration : IEntityTypeConfiguration<ApplicationUserRole>
    {
        public void Configure(EntityTypeBuilder<ApplicationUserRole> builder)
        {
            builder.HasOne(pt => pt.User).WithMany(t => t.UserRoles).HasForeignKey(p => p.UserId);
            builder.HasOne(pt => pt.Role).WithMany(t => t.UserRoles).HasForeignKey(pt => pt.RoleId);

           
        }
    }
}
