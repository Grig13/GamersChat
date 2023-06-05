namespace GamersChat.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? Content { get; set; }
        public DateTime Timestamp { get; set; }

        public string? UserId { get; set; }
        public ApplicationUser? Sender { get; set; }
    }
}
