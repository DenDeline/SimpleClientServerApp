using System;
using AutoMapper;
using SS.Application.Common.Mappings;
using SS.Domain.Entities;

namespace SS.Application.Users.Models
{
    public class UserCreateDto: IMapFrom<User>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastModified  { get; set; }

        private void Mapping(Profile profile)
        {
            profile.CreateMap<UserCreateDto, User>();
        }
    }
}
