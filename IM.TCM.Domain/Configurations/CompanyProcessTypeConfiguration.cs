using IM.TCM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Configurations
{
    public class CompanyProcessTypeConfiguration:IEntityTypeConfiguration<CompanyProcessType>
    {
        public void Configure(EntityTypeBuilder<CompanyProcessType> builder)
        {
            builder.HasKey(ub => new { ub.CompanyId, ub.ProcessTypeId});
            builder.HasOne(pt => pt.Company).WithMany(t => t.CompanyProcessTypes).HasForeignKey(p => p.CompanyId);
            builder.HasOne(pt => pt.ProcessType).WithMany(t => t.CompanyProcessTypes).HasForeignKey(pt => pt.ProcessTypeId);

        }
    }
}
