using IM.TCM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IM.TCM.Domain.Configurations
{
    public class TemplateConfiguration : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.HasKey(ub => new {ub.Id});

            builder.HasOne(pt => pt.BusinessUnit).WithMany(t => t.Templates).HasForeignKey(pt => pt.BUId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(pt => pt.CompanyCode).WithMany(t => t.Templates).HasForeignKey(pt => pt.CompanyId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(pt => pt.AccountGroup).WithMany(t => t.Templates).HasForeignKey(pt => pt.AccountGroupId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(pt => pt.ProcessType).WithMany(t => t.Templates).HasForeignKey(pt => pt.ProcessTypeId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
