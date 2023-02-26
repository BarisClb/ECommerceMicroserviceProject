using MediatR;
using SharedLibrary.Models;
using UserService.Application.Queries.User.GetUserById;

namespace UserService.Application.Queries.User
{
    public class GetUserByIdQueryRequest : IRequest<BaseResponse<GetUserByIdQueryResponse>>
    {
        public Guid Id { get; set; }
        public List<string>? Includes { get; set; }
    }
}
