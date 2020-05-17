using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IUwaDbContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Post> Posts { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
