using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mocktwitter_backend.Data;
using mocktwitter_backend.Models;

namespace mocktwitter_backend.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors("All")]
    public class TimelineController : ControllerBase
    {
        public TimelineController(MockTwitterContext context)
        {
            _context = context;
        }
        private readonly MockTwitterContext _context;

        [HttpGet("{userId}", Name = "GetTimeline")]
        public async Task<IEnumerable<MockTweetViewModel>> Get(int userId)
        {
            var user = await _context.Users.Include(u => u.FollowingUsers).FirstOrDefaultAsync(u => u.Id == userId);
            var tweets = await _context.MockTweets.Where(
                t => t.User == user || (user.FollowingUsers != null && user.FollowingUsers.Contains(t.User)))
                .OrderByDescending(t => t.TimeStamp)
                .ToListAsync();

            var viewModelList = new List<MockTweetViewModel>();
            tweets.ForEach(t => viewModelList.Add(new MockTweetViewModel { User = t.User.UserName, Tweet = t.Tweet, TimeStamp = t.TimeStamp.ToString() }));
            return viewModelList;
        }

        public class MockTweetViewModel
        {
            public string User { get; set; }
            public string Tweet { get; set; }
            public string TimeStamp { get; set; }
        }
    }
}
