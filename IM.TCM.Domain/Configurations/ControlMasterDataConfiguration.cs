using IM.TCM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Configurations
{
    public class ControlMasterDataConfiguration : IEntityTypeConfiguration<ControlMasterData>
    {
        public void Configure(EntityTypeBuilder<ControlMasterData> builder)
        {
            builder.HasKey(ub => new { ub.Id });

            builder.HasOne(pt => pt.TemplateControl).WithMany(t => t.ControlMasterData).HasForeignKey(pt => pt.TemplateControlId).OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
