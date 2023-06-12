using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GamersChat.Models;
using Microsoft.EntityFrameworkCore;

namespace GamersChatAPI.Models;
public partial class PostComment
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public Guid PostId { get; set; }
    public Post? Post { get; set; }
    public string userId { get; set; }
    public ApplicationUser? User { get; set; }

}
