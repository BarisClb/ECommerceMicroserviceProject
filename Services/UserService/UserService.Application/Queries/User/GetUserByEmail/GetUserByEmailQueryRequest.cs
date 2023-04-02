using MediatR;
using SharedLibrary.Models;

namespace UserService.Application.Queries.User.GetUserByEmail
{
    public class GetUserByEmailQueryRequest : IRequest<BaseResponse<GetUserByEmailQueryResponse>>
    {
        public string Email { get; set; }
        public List<string>? Includes { get; set; }
    }
}
