using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Repository;
using Application.Users.Models;
using AutoMapper;
using Domain.Entities;

namespace Infrastructure.Repositories
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
