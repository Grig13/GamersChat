namespace GamersChat.Models
{
    public class ApplicationUserDTO
    {
            public Guid Id { get; set; } = Guid.NewGuid();
            public Guid UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string ProfilePicture { get; set; }
            public string Description { get; set; }


    }
}
