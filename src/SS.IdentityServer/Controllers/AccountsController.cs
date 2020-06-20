using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SS.Application.Users.Models;
using SS.Infrastructure.Repositories;

namespace SS.IdentityServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountsController: Controller
    {
        private readonly UserRepository _userRepos;

        public AccountsController(UserRepository userRepos)
        {
            _userRepos = userRepos;
        }

        [HttpGet] 
        public ActionResult<IEnumerable<UserReadDto>> GetAllUsers()
        {
            var users = _userRepos.Get();
            if (users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [HttpGet("{id}",Name = "GetUserById")]
        public ActionResult<UserReadDto> GetUserById(object id)
        {
            var user = _userRepos.GetById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDto>> CreateUser(UserCreateDto userCreateDto)
        {
            if (userCreateDto == null)
            {
                return BadRequest();
            }
            var user = _userRepos.Insert(userCreateDto);
            await _userRepos.SaveChangesAsync();
            return CreatedAtRoute(nameof(GetUserById), new {Id = user}, user);
        }
    }
}
