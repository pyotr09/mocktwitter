namespace mocktwitter_backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public ICollection<MockTweet> Tweets { get; set; }
        public virtual ICollection<User> FollowedByUsers { get; set; }
        public virtual ICollection<User> FollowingUsers { get; set; }
    }
}
