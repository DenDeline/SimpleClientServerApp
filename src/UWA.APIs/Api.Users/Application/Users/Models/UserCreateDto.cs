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
    public class UserCreateDto: IMapFrom<User>
    {
        private void Mapping(Profile profile)
        {
            profile.CreateMap<UserCreateDto, User>();
        }
    }
}
