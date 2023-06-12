using System.ComponentModel.DataAnnotations;

namespace GamersChat.Models
{
    public class Connections
    {
        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid SignalrId { get; set; }
        public DateTime timeStamp { get; set; }
    }
}
