using MediatR;
using SharedLibrary.Models;

namespace UserService.Application.Commands.Address.DeleteAddressById
{
    public class DeleteAddressByIdCommandRequest : IRequest<BaseResponse<DeleteAddressByIdCommandResponse>>
    {
        public Guid Id { get; set; }
    }
}
