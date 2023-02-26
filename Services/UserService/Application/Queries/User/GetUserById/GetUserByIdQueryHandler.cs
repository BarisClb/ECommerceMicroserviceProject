using AutoMapper;
using MediatR;
using SharedLibrary.Models;
using System.Linq.Expressions;
using UserService.Application.Interfaces;

namespace UserService.Application.Queries.User.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQueryRequest, BaseResponse<GetUserByIdQueryResponse>>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserReadRepository userReadRepository, IMapper mapper)
        {
            _userReadRepository = userReadRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse<GetUserByIdQueryResponse>> Handle(GetUserByIdQueryRequest request, CancellationToken cancellationToken)
        {

            Expression<Func<Domain.Entities.User, bool>>? predicate = user => user.Id == request.Id;

            var user = request.Includes != null && request.Includes.Any() ? await _userReadRepository.GetFirstWhereAsync(predicate, request.Includes, cancellationToken)
                                                                          : await _userReadRepository.GetFirstWhereAsync(predicate, cancellationToken);

            if (user == null)
                return BaseResponse<GetUserByIdQueryResponse>.Fail($"User not found. Id: '{request.Id}'.", 404);

            return BaseResponse<GetUserByIdQueryResponse>.Success(_mapper.Map<GetUserByIdQueryResponse>(user), 200);
        }
    }
}
