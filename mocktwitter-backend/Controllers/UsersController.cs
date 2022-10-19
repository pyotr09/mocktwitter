using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mocktwitter_backend.Data;
using mocktwitter_backend.Models;

namespace mocktwitter_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("All")]
    public class UsersController : ControllerBase
    {
        private readonly MockTwitterContext _context;

        public UsersController(MockTwitterContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers()
        {
            var users = await _context.Users.Include(u => u.FollowingUsers).Include(u => u.FollowedByUsers).ToListAsync();
            var results = new List<UserViewModel>();
            foreach (var u in users)
            {
                var uvm = new UserViewModel { Id = u.Id, UserName = u.UserName, FollowedByUsers = new List<UserViewModel>(), FollowingUsers = new List<UserViewModel>()};
                foreach (var ufb in u.FollowedByUsers)
                {
                    uvm.FollowedByUsers.Add(new UserViewModel {Id = ufb.Id, UserName = ufb.UserName, FollowingUsers = null, FollowedByUsers = null });
                }
                foreach (var ufng in u.FollowingUsers)
                {
                    uvm.FollowingUsers.Add(new UserViewModel { Id = ufng.Id, UserName = ufng.UserName, FollowingUsers = null, FollowedByUsers = null });
                }
                results.Add(uvm);
            }

            return results;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }

    public class UserViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public List<UserViewModel> FollowedByUsers { get; set; }
        public List<UserViewModel> FollowingUsers { get; set; }
    }
}
