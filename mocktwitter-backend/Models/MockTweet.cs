namespace mocktwitter_backend.Models
{
    public class MockTweet
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Tweet { get; set; }
        public User? User { get; set; }
        public int UserId { get; set; }

    }
}
