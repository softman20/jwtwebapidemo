using IM.TCM.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace IM.TCM.Domain.Configurations
{
    public class RefreshTokenConfiguration: IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            //builder.HasKey(c => new { c.BeltLevelId, c.UserId });
            //builder.ToTable(DomainConsts.Tables.ApplicationUserBeltLevelTable);

            builder.HasAlternateKey(c=>c.UserId);
            //   .HasName("refreshToken_UserId");


            builder.HasAlternateKey(c=>c.Token);
            //  .HasName("refreshToken_Token");
        }
         
    }
}
