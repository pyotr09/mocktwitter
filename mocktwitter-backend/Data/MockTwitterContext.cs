using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using mocktwitter_backend.Models;

namespace mocktwitter_backend.Data
{
    public class MockTwitterContext : DbContext
    {
        public MockTwitterContext (DbContextOptions<MockTwitterContext> options)
            : base(options)
        {
        }

        public DbSet<mocktwitter_backend.Models.MockTweet> MockTweets { get; set; } = default!;
        public DbSet<mocktwitter_backend.Models.User> Users { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MockTweet>().HasOne<User>(s => s.User).WithMany(g => g.Tweets).HasForeignKey(s => s.UserId);
            modelBuilder.Entity<User>().HasData(new User { Id = 1, UserName = "ProjectCanary" });
            modelBuilder.Entity<User>().HasData(new User { Id = 2, UserName = "Trustwell" });

            modelBuilder.Entity<User>().HasMany(p => p.FollowedByUsers).WithMany(p => p.FollowingUsers)
                .UsingEntity(j => j.HasData(new { FollowedByUsersId = 1, FollowingUsersId = 2 }));

            modelBuilder.Entity<MockTweet>().HasData(new MockTweet { Id = 1, UserId = 1, Tweet = "Trustwell Certification", 
                TimeStamp = DateTime.Parse("2022-09-22T21:49:12Z") });

            modelBuilder.Entity<MockTweet>().HasData(new MockTweet
            {
                Id = 2,
                UserId = 1,
                Tweet = "Continous Monitoring",
                TimeStamp = DateTime.Parse("2022-09-22T21:25:00Z")
            });
            modelBuilder.Entity<MockTweet>().HasData(new MockTweet
            {
                Id = 3,
                UserId = 1,
                Tweet = "Responsibily Sourced GaS!",
                TimeStamp = DateTime.Parse("2022-09-22T21:00:12Z")
            });
            modelBuilder.Entity<MockTweet>().HasData(new MockTweet
            {
                Id = 4,
                UserId = 1,
                Tweet = "Measurement economy",
                TimeStamp = DateTime.Parse("2022-09-22T20:49:12Z")
            });
            modelBuilder.Entity<MockTweet>().HasData(new MockTweet
            {
                Id = 5,
                UserId = 1,
                Tweet = "Methane Concentrations",
                TimeStamp = DateTime.Parse("2022-09-21T15:00:12Z")
            });
            modelBuilder.Entity<MockTweet>().HasData(new MockTweet
            {
                Id = 6,
                UserId = 1,
                Tweet = "Quantified Total Site Emissions",
                TimeStamp = DateTime.Parse("2022-09-21T14:00:00Z")
            });
            modelBuilder.Entity<MockTweet>().HasData(new MockTweet
            {
                Id = 7,
                UserId = 1,
                Tweet = "Digital Canopy",
                TimeStamp = DateTime.Parse("2022-09-20T12:49:12Z")
            });
            modelBuilder.Entity<MockTweet>().HasData(new MockTweet
            {
                Id = 8,
                UserId = 1,
                Tweet = "Methane Moment",
                TimeStamp = DateTime.Parse("2022-09-20T07:49:12Z")
            });
            modelBuilder.Entity<MockTweet>().HasData(new MockTweet
            {
                Id = 9,
                UserId = 1,
                Tweet = "RSG",
                TimeStamp = DateTime.Parse("2022-09-20T03:49:12Z")
            });

            modelBuilder.Entity<MockTweet>().HasData(new MockTweet
            {
                Id = 10,
                UserId = 2,
                Tweet = "Verified Methane",
                TimeStamp = DateTime.Parse("2022-09-22T22:25:00Z")
            });
            modelBuilder.Entity<MockTweet>().HasData(new MockTweet
            {
                Id = 11,
                UserId = 2,
                Tweet = "Responsibily drilled and maintained",
                TimeStamp = DateTime.Parse("2022-09-22T21:20:00Z")
            });
            modelBuilder.Entity<MockTweet>().HasData(new MockTweet
            {
                Id = 12,
                UserId = 2,
                Tweet = "Demonstrate Water Stewardship",
                TimeStamp = DateTime.Parse("2022-09-22T20:30:12Z")
            });
            modelBuilder.Entity<MockTweet>().HasData(new MockTweet
            {
                Id = 13,
                UserId = 2,
                Tweet = "Reduce GHG Emissions",
                TimeStamp = DateTime.Parse("2022-09-20T12:15:12Z")
            });
            modelBuilder.Entity<MockTweet>().HasData(new MockTweet
            {
                Id = 14,
                UserId = 2,
                Tweet = "Emphasize community needs",
                TimeStamp = DateTime.Parse("2022-09-20T07:00:12Z")
            });
        }
    }
}
