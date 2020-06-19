using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Users.Models
{
    public class UserReadDto : IMapFrom<User>
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime Birthday { get; set; }

        public DateTime Created { get; set; }
        public DateTime LastModified  { get; set; }

        private void Mapping(Profile profile)
        {
            profile.CreateMap<UserReadDto, User>();
            profile.CreateMap<User, UserReadDto>();
        }
    }
}
