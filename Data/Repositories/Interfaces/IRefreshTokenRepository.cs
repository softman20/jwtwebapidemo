using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.Interfaces
{
   public interface IRefreshTokenRepository:IBaseRepository<RefreshToken>
    {
        RefreshToken GetToken(string refreshToken);
    }
}
