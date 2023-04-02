using UserService.Domain.Enums;

namespace UserService.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsAdmin { get; set; }
        public UserType UserType { get; set; }

        // Relations
        public ICollection<Address>? Addresses { get; set; }
    }
}
