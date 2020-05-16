using AutoMapper;
using UWA.Infrastructure.DTOs.UserDtos;
using UWA.Infrastructure.Models;

namespace UWA.Infrastructure.Profiles
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserReadModel>();
        }
    }
}
