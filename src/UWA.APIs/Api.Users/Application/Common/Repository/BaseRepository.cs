using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Mappings;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Repository
{
    public class BaseRepository<TEntity>: IRepository<TEntity>
        where TEntity : class
    {
        protected internal DbSet<TEntity> DbSet { get; }
        protected internal IUwaDbContext Context { get; }
        protected internal IMapper Mapper { get; }


        protected BaseRepository(
            IUwaDbContext context,
            IMapper mapper)
        {
            var dbSet = context.GetType().GetProperties()
                .FirstOrDefault(f => f.GetType()
                    .GetGenericArguments().All(t => t == typeof(TEntity)));

            DbSet = dbSet?.GetValue(context) as DbSet<TEntity>;
            Context = context;
            Mapper = mapper;
        }

        public virtual TOutDto Insert<TInDto, TOutDto>(TInDto entityToCreate)
            where TInDto : class, IMapFrom<TEntity>
            where TOutDto : class, IMapFrom<TEntity>
        {
            var entityEntry = DbSet.Add(Mapper.Map<TEntity>(entityToCreate));
            return Mapper.Map<TOutDto>(entityEntry.Entity);
        }

        public virtual void Delete<TDto>(TDto entityToDelete) 
            where TDto : class, IMapFrom<TEntity>
        {

        }

        public void Delete(object id)
        {
            
        }

        public virtual IEnumerable<TDto> Get<TDto>(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null) 
            where TDto : class, IMapFrom<TEntity>
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return Mapper.Map<IEnumerable<TDto>>(orderBy(query).ToList());
            }

            return Mapper.Map<IEnumerable<TDto>>(query.ToList());
        }

        public virtual TDto GetById<TDto>(object id) 
            where TDto : class, IMapFrom<TEntity>
        {
            try
            {
                return Mapper.Map<TDto>(DbSet.Find(id));
            }
            catch
            {
                return null;
            }
            
        }

        public virtual async Task<int> SaveChangesAsync(CancellationToken token = new CancellationToken())
        {
            return await Context.SaveChangesAsync(token);
        }
    }
}
