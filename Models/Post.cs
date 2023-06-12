using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GamersChat.Models;
using Microsoft.AspNet.Identity;
using Microsoft.EntityFrameworkCore;

namespace GamersChatAPI.Models;

public class Post
{
    public Guid Id { get; set; }
    public string Content { get; set; }
    public string UserId { get; set; }
    public ApplicationUser? User { get; set; }
    public ICollection<PostComment>? Comments { get; set; }
}
