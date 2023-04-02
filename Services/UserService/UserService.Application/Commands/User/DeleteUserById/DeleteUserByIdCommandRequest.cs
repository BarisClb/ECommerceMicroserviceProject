using MediatR;
using SharedLibrary.Models;

namespace UserService.Application.Commands.User.DeleteUserById
{
    public class DeleteUserByIdCommandRequest : IRequest<BaseResponse<DeleteUserByIdCommandResponse>>
    {
        public Guid Id { get; set; }
    }
}
