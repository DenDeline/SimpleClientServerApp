using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Mappings;

namespace Application.Common.Repository
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        void Delete<TDto>(TDto entityToDelete)
            where TDto : class, IMapFrom<TEntity>;

        void Delete(object id);

        IEnumerable<TDto> Get<TDto> (
                Expression<Func<TEntity, bool>> filter = null,
                Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            )
            where TDto : class, IMapFrom<TEntity>;
        
        TDto GetById<TDto>(object id)
            where TDto : class, IMapFrom<TEntity>;

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}
