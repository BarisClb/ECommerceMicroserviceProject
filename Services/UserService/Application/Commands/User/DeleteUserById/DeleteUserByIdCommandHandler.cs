using MediatR;
using SharedLibrary.Models;
using UserService.Application.Interfaces;

namespace UserService.Application.Commands.User.DeleteUserById
{
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommandRequest, BaseResponse<DeleteUserByIdCommandResponse>>
    {
        private readonly IUserWriteRepository _userWriteRepository;

        public DeleteUserByIdCommandHandler(IUserWriteRepository userWriteRepository)
        {
            _userWriteRepository = userWriteRepository;
        }


        public async Task<BaseResponse<DeleteUserByIdCommandResponse>> Handle(DeleteUserByIdCommandRequest request, CancellationToken cancellationToken)
        {
            var isDeleted = await _userWriteRepository.DeleteAsync(request.Id);

            if (!isDeleted)
                return BaseResponse<DeleteUserByIdCommandResponse>.Fail($"Failed to Delete User. Id: '{request.Id}'.", 400);

            return BaseResponse<DeleteUserByIdCommandResponse>.Success(new() { IsDeleted = isDeleted }, 200);
        }
    }
}
