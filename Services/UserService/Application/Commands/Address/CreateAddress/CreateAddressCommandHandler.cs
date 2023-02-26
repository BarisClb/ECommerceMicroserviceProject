using AutoMapper;
using MediatR;
using SharedLibrary.Models;
using UserService.Application.Interfaces;

namespace UserService.Application.Commands.Address.CreateAddress
{
    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommandRequest, BaseResponse<CreateAddressCommandResponse>>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IAddressWriteRepository _addressWriteRepository;
        private readonly IMapper _mapper;

        public CreateAddressCommandHandler(IUserReadRepository userReadRepository, IAddressWriteRepository addressWriteRepository, IMapper mapper)
        {
            _userReadRepository = userReadRepository;
            _addressWriteRepository = addressWriteRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse<CreateAddressCommandResponse>> Handle(CreateAddressCommandRequest request, CancellationToken cancellationToken)
        {
            if (await _userReadRepository.CountAsync(user => user.Id == request.UserId, cancellationToken) != 1)
                return BaseResponse<CreateAddressCommandResponse>.Fail($"User not found to Create Address. UserId: '{request.UserId}'.", 404);

            Domain.Entities.Address createAddress = new()
            {
                Name = request.Name,
                AddressLine = request.AddressLine,
                District = request.District,
                City = request.City,
                PostalCode = request.PostalCode,
                UserId = request.UserId
            };

            var newAddress = await _addressWriteRepository.AddAsync(createAddress);
            if (newAddress == null)
                return BaseResponse<CreateAddressCommandResponse>.Fail($"Failed to Create Address.", 500);

            return BaseResponse<CreateAddressCommandResponse>.Success(_mapper.Map<CreateAddressCommandResponse>(newAddress), 201);
        }
    }
}
