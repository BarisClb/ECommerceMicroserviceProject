using MediatR;
using SharedLibrary.Models;
using UserService.Application.Queries.User.GetUserByEmail;

namespace UserService.Application.Queries.User
{
    public class GetUserByEmailQueryRequest : IRequest<BaseResponse<GetUserByEmailQueryResponse>>
    {
        public string Email { get; set; }
        public List<string>? Includes { get; set; }
    }
}
