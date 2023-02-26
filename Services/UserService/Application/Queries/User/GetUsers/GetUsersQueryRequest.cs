using MediatR;
using SharedLibrary.Models;
using UserService.Application.Enums;
using UserService.Application.Queries.User.GetUsers;

namespace UserService.Application.Queries.User
{
    public class GetUsersQueryRequest : SortedListRequest, IRequest<BaseResponse<IEnumerable<GetUsersQueryResponse>>>
    {
        public UserSearchInType? SearchIn { get; set; }
        public UserOrderByType? OrderBy { get; set; }
        public List<string>? Includes { get; set; }
    }
}
