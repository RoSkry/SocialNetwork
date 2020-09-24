using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialNetProject.Data;
using SocialNetProject.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetProject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ISocialNetRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(ISocialNetRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _repo.GetUsers();

            var usersToReturn = _mapper.Map<IEnumerable<UserForListDto>>(users);

            return Ok(usersToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsers(int id)
        {
            var user = await _repo.GetUser(id);

            var userToReturn = _mapper.Map<UserForDetailDto>(user);

            return Ok(userToReturn);
        }
    }
}
