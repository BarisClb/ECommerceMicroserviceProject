using MediatR;
using SharedLibrary.Models;
using UserService.Application.Queries.User.GetUserByUsername;

namespace UserService.Application.Queries.User
{
    public class GetUserByUsernameQueryRequest : IRequest<BaseResponse<GetUserByUsernameQueryResponse>>
    {
        public string Username { get; set; }
        public List<string>? Includes { get; set; }
    }
}
