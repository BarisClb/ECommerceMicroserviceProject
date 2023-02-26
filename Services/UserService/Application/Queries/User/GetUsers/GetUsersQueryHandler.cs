using AutoMapper;
using MediatR;
using SharedLibrary.Models;
using System.Linq.Expressions;
using UserService.Application.Enums;
using UserService.Application.Interfaces;

namespace UserService.Application.Queries.User.GetUsers
{
    public class GetUsersQueryHandler : IRequestHandler<GetUsersQueryRequest, BaseResponse<IEnumerable<GetUsersQueryResponse>>>
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly IMapper _mapper;

        public GetUsersQueryHandler(IUserReadRepository userReadRepository, IMapper mapper)
        {
            _userReadRepository = userReadRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse<IEnumerable<GetUsersQueryResponse>>> Handle(GetUsersQueryRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Entities.User, bool>>? predicate = default;
            if (!string.IsNullOrWhiteSpace(request.SearchWord))
            {
                _ = request.SearchIn switch
                {
                    UserSearchInType.Name => predicate = user => user.Name.Contains(request.SearchWord),
                    UserSearchInType.Username => predicate = user => user.Username.Contains(request.SearchWord),
                    UserSearchInType.Email => predicate = user => user.Email.Contains(request.SearchWord),
                    _ => predicate = user => user.Name.Contains(request.SearchWord)
                };
            }

            Func<IQueryable<Domain.Entities.User>, IOrderedQueryable<Domain.Entities.User>>? orderBy = default;
            if (request.OrderBy != null || request.IsReversed)
            {
                _ = request.OrderBy switch
                {
                    UserOrderByType.CreatedOn => orderBy = request.IsReversed ? query => query.OrderByDescending(user => user.CreatedOn) : query => query.OrderBy(user => user.CreatedOn),
                    UserOrderByType.ModifiedOn => orderBy = request.IsReversed ? query => query.OrderByDescending(user => user.ModifiedOn) : query => query.OrderBy(user => user.ModifiedOn),
                    UserOrderByType.Name => orderBy = request.IsReversed ? query => query.OrderByDescending(user => user.Name) : query => query.OrderBy(user => user.Name),
                    UserOrderByType.Username => orderBy = request.IsReversed ? query => query.OrderByDescending(user => user.Username) : query => query.OrderBy(user => user.Username),
                    UserOrderByType.IsAdmin => orderBy = request.IsReversed ? query => query.OrderByDescending(user => user.IsAdmin) : query => query.OrderBy(user => user.IsAdmin),
                    UserOrderByType.UserType => orderBy = request.IsReversed ? query => query.OrderByDescending(user => user.UserType) : query => query.OrderBy(user => user.UserType),
                    _ => orderBy = request.IsReversed ? query => query.OrderByDescending(user => user.CreatedOn) : query => query.OrderBy(user => user.CreatedOn)
                };
            }

            var users = await _userReadRepository.GetAsync(request.PageNumber, request.PageSize, orderBy, predicate, request.Includes, cancellationToken);

            if (users == null)
                return BaseResponse<IEnumerable<GetUsersQueryResponse>>.Fail("Failed to retrieve Users.", 500);

            int? count = default;
            if (request.NeedCount)
                count = await _userReadRepository.CountAsync(predicate, cancellationToken);

            var sorting = new SortedListResponse() { PageNumber = request.PageNumber, PageSize = request.PageSize, IsReversed = request.IsReversed, NeedCount = request.NeedCount, Count = count, SearchWord = request.SearchWord };

            return BaseResponse<IEnumerable<GetUsersQueryResponse>>.Success(_mapper.Map<IEnumerable<GetUsersQueryResponse>>(users), 200, sorting);
        }
    }
}
