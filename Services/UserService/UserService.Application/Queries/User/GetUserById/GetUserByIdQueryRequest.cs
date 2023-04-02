using MediatR;
using SharedLibrary.Models;

namespace UserService.Application.Queries.User.GetUserById
{
    public class GetUserByIdQueryRequest : IRequest<BaseResponse<GetUserByIdQueryResponse>>
    {
        public Guid Id { get; set; }
        public List<string>? Includes { get; set; }
    }
}
