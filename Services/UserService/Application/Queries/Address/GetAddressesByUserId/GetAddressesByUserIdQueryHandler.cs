using AutoMapper;
using MediatR;
using SharedLibrary.Extensions;
using SharedLibrary.Models;
using System.Linq.Expressions;
using UserService.Application.Enums;
using UserService.Application.Interfaces;

namespace UserService.Application.Queries.Address.GetAddressesByUserId
{
    public class GetAddressesByUserIdQueryHandler : IRequestHandler<GetAddressesByUserIdQueryRequest, BaseResponse<IEnumerable<GetAddressesByUserIdQueryResponse>>>
    {
        private readonly IAddressReadRepository _addressReadRepository;
        private readonly IMapper _mapper;

        public GetAddressesByUserIdQueryHandler(IAddressReadRepository addressReadRepository, IMapper mapper)
        {
            _addressReadRepository = addressReadRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse<IEnumerable<GetAddressesByUserIdQueryResponse>>> Handle(GetAddressesByUserIdQueryRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Entities.Address, bool>> predicate = address => address.UserId == request.UserId;
            if (!string.IsNullOrWhiteSpace(request.SearchWord))
            {
                _ = request.SearchIn switch
                {
                    AddressSearchInType.AddressLine => predicate = predicate.And(address => address.AddressLine.Contains(request.SearchWord)),
                    AddressSearchInType.District => predicate = predicate.And(address => address.District.Contains(request.SearchWord)),
                    AddressSearchInType.City => predicate = predicate.And(address => address.City.Contains(request.SearchWord)),
                    AddressSearchInType.PostalCode => predicate = predicate.And(address => address.PostalCode.Contains(request.SearchWord)),
                    _ => predicate = predicate.And(address => address.Name.Contains(request.SearchWord))
                };
            }

            Func<IQueryable<Domain.Entities.Address>, IOrderedQueryable<Domain.Entities.Address>>? orderBy = default;
            if (request.OrderBy != null || request.IsReversed)
            {
                _ = request.OrderBy switch
                {
                    AddressOrderByType.CreatedOn => orderBy = request.IsReversed ? qeury => qeury.OrderByDescending(address => address.CreatedOn) : qeury => qeury.OrderBy(address => address.CreatedOn),
                    AddressOrderByType.ModifiedOn => orderBy = request.IsReversed ? qeury => qeury.OrderByDescending(address => address.ModifiedOn) : qeury => qeury.OrderBy(address => address.ModifiedOn),
                    AddressOrderByType.Name => orderBy = request.IsReversed ? qeury => qeury.OrderByDescending(address => address.Name) : qeury => qeury.OrderBy(address => address.Name),
                    AddressOrderByType.AddressLine => orderBy = request.IsReversed ? qeury => qeury.OrderByDescending(address => address.AddressLine) : qeury => qeury.OrderBy(address => address.AddressLine),
                    AddressOrderByType.District => orderBy = request.IsReversed ? qeury => qeury.OrderByDescending(address => address.District) : qeury => qeury.OrderBy(address => address.District),
                    AddressOrderByType.City => orderBy = request.IsReversed ? qeury => qeury.OrderByDescending(address => address.City) : qeury => qeury.OrderBy(address => address.City),
                    AddressOrderByType.PostalCode => orderBy = request.IsReversed ? qeury => qeury.OrderByDescending(address => address.PostalCode) : qeury => qeury.OrderBy(address => address.PostalCode),
                    _ => orderBy = request.IsReversed ? qeury => qeury.OrderByDescending(address => address.CreatedOn) : qeury => qeury.OrderBy(address => address.CreatedOn)
                };
            }

            var addresses = await _addressReadRepository.GetAsync(request.PageNumber, request.PageSize, orderBy, predicate, request.Includes, cancellationToken);

            if (addresses == null)
                return BaseResponse<IEnumerable<GetAddressesByUserIdQueryResponse>>.Fail($"Failed to retrieve Addresses for User. UserId: '{request.UserId}'.", 500);

            int? count = default;
            if (request.NeedCount)
                count = await _addressReadRepository.CountAsync(predicate, cancellationToken);

            var sorting = new SortedListResponse() { PageNumber = request.PageNumber, PageSize = request.PageSize, IsReversed = request.IsReversed, NeedCount = request.NeedCount, Count = count, SearchWord = request.SearchWord };

            return BaseResponse<IEnumerable<GetAddressesByUserIdQueryResponse>>.Success(_mapper.Map<IEnumerable<GetAddressesByUserIdQueryResponse>>(addresses), 200, sorting);
        }
    }
}
