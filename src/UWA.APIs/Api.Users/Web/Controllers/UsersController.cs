using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using UWA.Infrastructure.Data;
using UWA.Infrastructure.DTOs.UserDtos;
using UWA.Infrastructure.Models;

namespace UWA.UserApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("_myAllowSpecificOrigins")]
    public class UsersController: Controller
    {
        private readonly IUserRepo _userRepos;
        private readonly IMapper _mapper;

        public UsersController(IUserRepo userRepos, IMapper mapper)
        {
            _userRepos = userRepos;
            _mapper = mapper;
        }

        [HttpGet] 
        public async Task<ActionResult<IEnumerable<UserReadDto>>> GetAllUsers()
        {
            var users = await _userRepos.GetAllUsersAsync();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<UserReadDto>>(users));
        }

        [HttpGet("{id}",Name = "GetUserById")]
        public async Task<ActionResult<UserReadDto>> GetUserById(int id)
        {
            var user = await _userRepos.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserReadDto>(user));
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDto>> CreateUser(UserCreateDto userCreateDto)
        {
            if (userCreateDto == null)
            {
                return BadRequest();
            }

            var userModel = _mapper.Map<User>(userCreateDto);
            await _userRepos.CreateUserAsync(userModel);
            await _userRepos.SaveChangesAsync();

            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return CreatedAtRoute(nameof(GetUserById), new {Id = userModel.Id}, userReadDto);
        }
    }
}
