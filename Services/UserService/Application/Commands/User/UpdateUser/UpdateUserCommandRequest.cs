using MediatR;
using SharedLibrary.Models;
using UserService.Domain.Enums;

namespace UserService.Application.Commands.User.UpdateUser
{
    public class UpdateUserCommandRequest : IRequest<BaseResponse<UpdateUserCommandResponse>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? IsAdmin { get; set; }
        public UserType? UserType { get; set; }
    }
}
