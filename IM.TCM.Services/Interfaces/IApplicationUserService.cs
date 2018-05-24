using IM.TCM.Domain.Dtos;
using IM.TCM.Domain.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IM.TCM.Services.Interfaces
{
    public interface IApplicationUserService : IBaseService<ApplicationUser>
    {
        string CreateJwt(IEnumerable<Claim> claims);
        Task<UserDto> AddUserAsync(UserDto user);
        Task UpdateUserAsync(UserDto user);
        Task DeleteUserAsync(string sgId);
        string RefreshToken(string token);
        UserDto GetUser(string sgid);
        IEnumerable<UserDto> GetAllUsers();
        IEnumerable<int> ListBusinessUnits(ApplicationUser user);
    }
}
