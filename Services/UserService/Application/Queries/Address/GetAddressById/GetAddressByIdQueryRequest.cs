using MediatR;
using SharedLibrary.Models;
using UserService.Application.Queries.Address.GetAddressById;

namespace UserService.Application.Queries.Address
{
    public class GetAddressByIdQueryRequest : IRequest<BaseResponse<GetAddressByIdQueryResponse>>
    {
        public Guid Id { get; set; }
        public List<string>? Includes { get; set; }
    }
}
