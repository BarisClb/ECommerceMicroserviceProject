using MediatR;
using SharedLibrary.Models;
using UserService.Application.Interfaces;

namespace UserService.Application.Commands.Address.DeleteAddressById
{
    public class DeleteAddressByIdCommandHandler : IRequestHandler<DeleteAddressByIdCommandRequest, BaseResponse<DeleteAddressByIdCommandResponse>>
    {
        private readonly IAddressWriteRepository _addressWriteRepository;

        public DeleteAddressByIdCommandHandler(IAddressWriteRepository addressWriteRepository)
        {
            _addressWriteRepository = addressWriteRepository;
        }


        public async Task<BaseResponse<DeleteAddressByIdCommandResponse>> Handle(DeleteAddressByIdCommandRequest request, CancellationToken cancellationToken)
        {
            var isDeleted = await _addressWriteRepository.DeleteAsync(request.Id);

            if (!isDeleted)
                return BaseResponse<DeleteAddressByIdCommandResponse>.Fail($"Failed to Delete Address. AddressId: '{request.Id}'.", 400);

            return BaseResponse<DeleteAddressByIdCommandResponse>.Success(new() { IsDeleted = isDeleted }, 200);
        }
    }
}
