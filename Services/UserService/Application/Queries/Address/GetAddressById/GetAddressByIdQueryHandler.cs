using AutoMapper;
using MediatR;
using SharedLibrary.Models;
using UserService.Application.Interfaces;

namespace UserService.Application.Queries.Address.GetAddressById
{
    public class GetAddressByIdQueryHandler : IRequestHandler<GetAddressByIdQueryRequest, BaseResponse<GetAddressByIdQueryResponse>>
    {
        private readonly IAddressReadRepository _addressReadRepository;
        private readonly IMapper _mapper;

        public GetAddressByIdQueryHandler(IAddressReadRepository addressReadRepository, IMapper mapper)
        {
            _addressReadRepository = addressReadRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse<GetAddressByIdQueryResponse>> Handle(GetAddressByIdQueryRequest request, CancellationToken cancellationToken)
        {
            var address = request.Includes != null && request.Includes.Any() ? await _addressReadRepository.GetByIdAsync(request.Id, request.Includes, cancellationToken)
                                                                             : await _addressReadRepository.GetByIdAsync(request.Id, cancellationToken);
            if (address == null)
                return BaseResponse<GetAddressByIdQueryResponse>.Fail($"Address not found. Id: '{request.Id}'.", 404);

            return BaseResponse<GetAddressByIdQueryResponse>.Success(_mapper.Map<GetAddressByIdQueryResponse>(address), 200);
        }
    }
}
