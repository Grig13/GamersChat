namespace GamersChat.Models
{
    public class Message
    {
        public Guid Id { get; set;  }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        public Guid SenderId { get; set; }
        public ApplicationUser Sender { get; set; }

        public Guid ReceiverId { get; set; }
        public ApplicationUser Receiver { get; set; }

        public Guid ProductId { get; set; }

        public Product Product { get; set; }
    }
}
