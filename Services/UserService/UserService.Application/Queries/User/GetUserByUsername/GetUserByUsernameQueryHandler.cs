using AutoMapper;
using MediatR;
using SharedLibrary.Models;
using System.Linq.Expressions;
using UserService.Application.Interfaces;

namespace UserService.Application.Queries.User.GetUserByUsername
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQueryRequest, BaseResponse<GetUserByUsernameQueryResponse>>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMapper _mapper;

        public GetUserByUsernameQueryHandler(IUserReadRepository userReadRepository, IMapper mapper)
        {
            _userReadRepository = userReadRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse<GetUserByUsernameQueryResponse>> Handle(GetUserByUsernameQueryRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Entities.User, bool>>? predicate = user => user.Username == request.Username;

            var user = request.Includes != null && request.Includes.Any() ? await _userReadRepository.GetFirstWhereAsync(predicate, request.Includes, cancellationToken)
                                                                          : await _userReadRepository.GetFirstWhereAsync(predicate, cancellationToken);

            if (user == null)
                return BaseResponse<GetUserByUsernameQueryResponse>.Fail($"User not found. Username: '{request.Username}'.", 404);

            return BaseResponse<GetUserByUsernameQueryResponse>.Success(_mapper.Map<GetUserByUsernameQueryResponse>(user), 200);
        }
    }
}
