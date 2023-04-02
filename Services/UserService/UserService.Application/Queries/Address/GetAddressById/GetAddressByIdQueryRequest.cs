using MediatR;
using SharedLibrary.Models;

namespace UserService.Application.Queries.Address.GetAddressById
{
    public class GetAddressByIdQueryRequest : IRequest<BaseResponse<GetAddressByIdQueryResponse>>
    {
        public Guid Id { get; set; }
        public List<string>? Includes { get; set; }
    }
}
