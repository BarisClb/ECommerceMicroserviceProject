using AutoMapper;
using MediatR;
using SharedLibrary.Models;
using UserService.Application.Interfaces;

namespace UserService.Application.Commands.Address.UpdateAddress
{
    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommandRequest, BaseResponse<UpdateAddressCommandResponse>>
    {
        private readonly IAddressReadRepository _addressReadRepository;
        private readonly IAddressWriteRepository _addressWriteRepository;
        private readonly IMapper _mapper;

        public UpdateAddressCommandHandler(IAddressReadRepository addressReadRepository, IAddressWriteRepository addressWriteRepository, IMapper mapper)
        {
            _addressReadRepository = addressReadRepository;
            _addressWriteRepository = addressWriteRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse<UpdateAddressCommandResponse>> Handle(UpdateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            Domain.Entities.Address oldAddress = await _addressReadRepository.GetByIdAsync(request.Id, cancellationToken);

            if (oldAddress == null)
                return BaseResponse<UpdateAddressCommandResponse>.Fail($"Address not found for Update Address. AddressId: '{request.Id}'.", 404);

            if (!string.IsNullOrEmpty(request.Name))
                oldAddress.Name = request.Name;
            if (!string.IsNullOrEmpty(request.AddressLine))
                oldAddress.AddressLine = request.AddressLine;
            if (!string.IsNullOrEmpty(request.District))
                oldAddress.District = request.District;
            if (!string.IsNullOrEmpty(request.City))
                oldAddress.City = request.City;
            if (!string.IsNullOrEmpty(request.PostalCode))
                oldAddress.PostalCode = request.PostalCode;
            if (request.UserId != null && request.UserId != Guid.Empty)
                oldAddress.UserId = request.UserId ?? oldAddress.UserId;

            var updatedAddress = await _addressWriteRepository.UpdateAsync(oldAddress);

            if (updatedAddress == null)
                return BaseResponse<UpdateAddressCommandResponse>.Fail($"Failed to Update Address. AddressId: '{request.Id}'.", 500);

            return BaseResponse<UpdateAddressCommandResponse>.Success(_mapper.Map<UpdateAddressCommandResponse>(updatedAddress), 200);
        }
    }
}
