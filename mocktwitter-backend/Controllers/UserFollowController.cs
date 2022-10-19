using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mocktwitter_backend.Data;
using mocktwitter_backend.Models;
using System.Runtime.InteropServices;

namespace mocktwitter_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("All")]
    public class UserFollowController : ControllerBase
    {
        public UserFollowController(MockTwitterContext context)
        {
            _context = context;
        }
        private readonly MockTwitterContext _context;

        [HttpPost]
        public async Task UpdateUserFollows(UserFollowViewModel userFollows)
        {
            var activeUser = await _context.Users.Include(u => u.FollowingUsers).FirstOrDefaultAsync(u => u.Id == userFollows.ActiveUserId);
            if (activeUser == null) throw new Exception("Active user not found.");
            activeUser.FollowingUsers = new List<User>();
            foreach(var followingUserId in userFollows.FollowedUserIds)
            {
                var followingUser = await _context.Users.FindAsync(followingUserId);
                if (followingUser == null) throw new Exception("User to be followed not found.");
                activeUser.FollowingUsers.Add(followingUser);
            }

            await _context.SaveChangesAsync();
        }
    }

    public class UserFollowViewModel
    {
        public int ActiveUserId { get; set; }
        public List<int> FollowedUserIds { get; set; }
    }
}
