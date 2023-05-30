namespace GamersChat.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string IsNew { get; set; }
        public string? ImageUrl { get; set; }   
        public string? Category { get; set; }
        public string CanDeliver { get; set; }
        public string? City { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }

        public Guid? UserId { get; set; }
        public ApplicationUser? User { get; set; }


        public Product()
        {
            CreatedDate = DateTime.Now;
        }

    }
}
