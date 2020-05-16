using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UWA.Infrastructure.DTOs.UserDtos;
using UWA.Infrastructure.Models;

namespace UWA.Infrastructure.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly UserContext _userContext;

        public UserRepo(
            UserContext userContext)
        {
            _userContext = userContext;
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await _userContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _userContext.Users.ToListAsync();
        }

        public async Task CreateUserAsync(User user)
        {
            await _userContext.Users.AddAsync(user);
        }

        public async Task SaveChangesAsync()
        {
            await _userContext.SaveChangesAsync();
        }
    }
}
