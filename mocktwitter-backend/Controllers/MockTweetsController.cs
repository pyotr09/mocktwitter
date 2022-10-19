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
    public class MockTweetsController : ControllerBase
    {
        private readonly MockTwitterContext _context;

        public MockTweetsController(MockTwitterContext context)
        {
            _context = context;
        }

        // GET: /MockTweets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MockTweet>>> GetMockTweet()
        {
            return await _context.MockTweets.ToListAsync();
        }

        // GET: /MockTweets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MockTweet>> GetMockTweet(int id)
        {
            var mockTweet = await _context.MockTweets.FindAsync(id);

            if (mockTweet == null)
            {
                return NotFound();
            }

            return mockTweet;
        }

        // POST: /MockTweets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MockTweet>> PostMockTweet(MockTweet mockTweet)
        {
            _context.MockTweets.Add(mockTweet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMockTweet", new { id = mockTweet.Id }, mockTweet);
        }

        private bool MockTweetExists(int id)
        {
            return _context.MockTweets.Any(e => e.Id == id);
        }
    }
}
