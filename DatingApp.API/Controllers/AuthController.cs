using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController: ControllerBase
    {
        private readonly IAuthrepository _repo;

        public AuthController(IAuthrepository repo)
        {
            _repo = repo;

        }

        public async Task<IActionResult> Register(string username, string password)
        {
            username = username.ToLower();

            if(await _repo.UserExists(username))
            {
                return BadRequest("Username Already Exists");
            }

            var userToCreate = new User
            {
                Username = username

            };
            var createdUser = await _repo.Register(userToCreate, password);

            return StatusCode(201);
        }

    }
}