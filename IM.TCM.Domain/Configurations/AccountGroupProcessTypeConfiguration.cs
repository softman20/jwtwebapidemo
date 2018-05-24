using IM.TCM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Configurations
{
    public class AccountGroupProcessTypeConfiguration : IEntityTypeConfiguration<AccountGroupProcessType>
    {
        public void Configure(EntityTypeBuilder<AccountGroupProcessType> builder)
        {
            builder.HasKey(ub => new { ub.AccountGroupId, ub.ProcessTypeId});
            builder.HasOne(pt => pt.AccountGroup).WithMany(t => t.AccountGroupProcessType).HasForeignKey(p => p.AccountGroupId);
            builder.HasOne(pt => pt.ProcessType).WithMany(t => t.AccountGroupProcessType).HasForeignKey(pt => pt.ProcessTypeId);

        }
    }
}
