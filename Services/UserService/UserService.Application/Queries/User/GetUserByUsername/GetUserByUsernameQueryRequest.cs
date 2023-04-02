using MediatR;
using SharedLibrary.Models;

namespace UserService.Application.Queries.User.GetUserByUsername
{
    public class GetUserByUsernameQueryRequest : IRequest<BaseResponse<GetUserByUsernameQueryResponse>>
    {
        public string Username { get; set; }
        public List<string>? Includes { get; set; }
    }
}
