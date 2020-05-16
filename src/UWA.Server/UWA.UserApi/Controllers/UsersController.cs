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

namespace UWA.UserApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
        public async Task<ActionResult<IEnumerable<UserReadModel>>> GetAllUsers()
        {
            var users = await _userRepos.GetUsersAsync();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<IEnumerable<UserReadModel>>(users));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadModel>> GetUserById(int id)
        {
            var user = await _userRepos.GetUserAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<UserReadModel>(user));
        }
    }
}
