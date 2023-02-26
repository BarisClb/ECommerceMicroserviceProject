using MediatR;
using SharedLibrary.Models;
using UserService.Application.Enums;
using UserService.Application.Queries.Address.GetAddressesByUserId;

namespace UserService.Application.Queries.Address
{
    public class GetAddressesByUserIdQueryRequest : SortedListRequest, IRequest<BaseResponse<IEnumerable<GetAddressesByUserIdQueryResponse>>>
    {
        public Guid UserId { get; set; }
        public AddressSearchInType? SearchIn { get; set; }
        public AddressOrderByType? OrderBy { get; set; }
        public List<string>? Includes { get; set; }
    }
}
