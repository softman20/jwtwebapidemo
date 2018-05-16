using IM.TCM.Data.EF;
using IM.TCM.Data.Repositories.Interfaces;
using IM.TCM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;


namespace IM.TCM.Data.Repositories
{
    public class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(TCMContext context) : base(context)
        {


        }

        public RefreshToken GetToken(string refreshToken)
        {
         return this.DbSet.AsQueryable().Include(x=>x.User).SingleOrDefault(i => i.Token == refreshToken);
        }
    }
}
