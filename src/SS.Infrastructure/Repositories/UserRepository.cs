using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using SS.Application.Common.Interfaces;
using SS.Application.Common.Repository;
using SS.Application.Users.Models;
using SS.Domain.Entities;

namespace SS.Infrastructure.Repositories
{
    public class UserRepository: BaseRepository<User>
    {
        public UserRepository(
            IUwaDbContext context,
            IMapper mapper) 
            : base(context, mapper)
        {

        }

        public IEnumerable<UserReadDto> Get(
            Expression<Func<User, bool>> filter = null, 
            Func<IQueryable<User>, IOrderedQueryable<User>> orderBy = null)
        {
            return base.Get<UserReadDto>(filter, orderBy);
        }

        public UserReadDto GetById(object id)
        {
            return base.GetById<UserReadDto>(id);
        }

        public UserReadDto Insert(UserCreateDto entityToCreate)
        {
            return base.Insert<UserCreateDto, UserReadDto>(entityToCreate);
        }
    }
}
