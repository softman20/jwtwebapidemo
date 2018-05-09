using Data.EF;
using Data.Repositories.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq;


namespace Data.Repositories
{
    public class RefreshTokenRepository : BaseRepository<RefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(JWTDemoContext context) : base(context)
        {


        }

        public RefreshToken GetToken(string refreshToken)
        {
         return this.DbSet.AsQueryable().Include(x=>x.User).SingleOrDefault(i => i.Token == refreshToken);
        }
    }
}
