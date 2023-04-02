using MediatR;
using SharedLibrary.Models;
using UserService.Application.Enums;
using UserService.Application.Helpers;

namespace UserService.Application.Queries.Address.GetAddresses
{
    public class GetAddressesQueryRequest : SortedListRequest, IRequest<BaseResponse<IEnumerable<GetAddressesQueryResponse>>>
    {
        public AddressSearchInType? SearchIn { get; set; }
        public AddressOrderByType? OrderBy { get; set; }
        public List<string>? Includes { get; set; }
    }
}
