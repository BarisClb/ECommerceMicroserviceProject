using AutoMapper;
using MediatR;
using SharedLibrary.Models;
using System.Linq.Expressions;
using UserService.Application.Interfaces;

namespace UserService.Application.Queries.User.GetUserByEmail
{
    public class GetUserByEmailQueryHandler : IRequestHandler<GetUserByEmailQueryRequest, BaseResponse<GetUserByEmailQueryResponse>>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMapper _mapper;

        public GetUserByEmailQueryHandler(IUserReadRepository userReadRepository, IMapper mapper)
        {
            _userReadRepository = userReadRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse<GetUserByEmailQueryResponse>> Handle(GetUserByEmailQueryRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Entities.User, bool>>? predicate = user => user.Email == request.Email;

            var user = request.Includes != null && request.Includes.Any() ? await _userReadRepository.GetFirstWhereAsync(predicate, request.Includes, cancellationToken)
                                                                          : await _userReadRepository.GetFirstWhereAsync(predicate, cancellationToken);

            if (user == null)
                return BaseResponse<GetUserByEmailQueryResponse>.Fail($"User not found. Email: '{request.Email}'.", 404);

            return BaseResponse<GetUserByEmailQueryResponse>.Success(_mapper.Map<GetUserByEmailQueryResponse>(user), 200);
        }
    }
}
