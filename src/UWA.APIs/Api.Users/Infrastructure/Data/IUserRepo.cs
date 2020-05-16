using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UWA.Infrastructure.DTOs.UserDtos;
using UWA.Infrastructure.Models;

namespace UWA.Infrastructure.Data
{
    public interface IUserRepo
    {
        Task<User> GetUserAsync(int id);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task CreateUserAsync(User user);
        Task SaveChangesAsync();
    }
}
