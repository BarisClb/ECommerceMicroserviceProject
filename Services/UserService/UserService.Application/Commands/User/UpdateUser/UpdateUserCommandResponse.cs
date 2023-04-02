using UserService.Domain.Enums;

namespace UserService.Application.Commands.User.UpdateUser
{
    public class UpdateUserCommandResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public UserType UserType { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
