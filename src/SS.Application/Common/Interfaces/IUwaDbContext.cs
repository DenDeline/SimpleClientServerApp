using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SS.Domain.Entities;

namespace SS.Application.Common.Interfaces
{
    public interface IUwaDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Post> Posts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
