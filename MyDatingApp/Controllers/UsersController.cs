using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyDatingApp.Data;
using MyDatingApp.Entities;
using System.Reflection.Metadata.Ecma335;

namespace MyDatingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public UsersController(DataContext context) { 
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _dataContext.appusers.ToListAsync();

            return users;
        }

        [HttpGet ("{id}")]

        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user =  await _dataContext.appusers.FindAsync(id);

            if (user == null)
            {
                return NotFound(); // Assuming you want to return a 404 Not Found if the user doesn't exist
            }
            return user;
        }
    }
}
