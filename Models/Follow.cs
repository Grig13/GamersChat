using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GamersChat.Models
{
    public class Follow
    {
        public Guid Id { get; set; }

        [ForeignKey("Follower")]
        public string FollowerId { get; set; }
        public virtual ApplicationUser Follower { get; set; }

        [ForeignKey("FollowedUser")]
        public string FollowedUserId { get; set; }
        public virtual ApplicationUser FollowedUser { get; set; }
    }
}
