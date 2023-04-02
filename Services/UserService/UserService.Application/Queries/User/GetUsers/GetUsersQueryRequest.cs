using MediatR;
using SharedLibrary.Models;
using UserService.Application.Helpers;

namespace UserService.Application.Queries.User.GetUsers
{
    public class GetUsersQueryRequest : SortedListRequest, IRequest<BaseResponse<IEnumerable<GetUsersQueryResponse>>>
    {
        public UserSearchInType? SearchIn { get; set; }
        public UserOrderByType? OrderBy { get; set; }
        public List<string>? Includes { get; set; }
    }
}
