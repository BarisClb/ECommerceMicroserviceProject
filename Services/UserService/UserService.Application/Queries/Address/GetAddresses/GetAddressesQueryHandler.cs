using AutoMapper;
using MediatR;
using SharedLibrary.Models;
using System.Linq.Expressions;
using UserService.Application.Enums;
using UserService.Application.Helpers;
using UserService.Application.Interfaces;

namespace UserService.Application.Queries.Address.GetAddresses
{
    public class GetAddressesQueryHandler : IRequestHandler<GetAddressesQueryRequest, BaseResponse<IEnumerable<GetAddressesQueryResponse>>>
    {
        private readonly IAddressReadRepository _addressReadRepository;
        private readonly IMapper _mapper;

        public GetAddressesQueryHandler(IAddressReadRepository addressReadRepository, IMapper mapper)
        {
            _addressReadRepository = addressReadRepository;
            _mapper = mapper;
        }


        public async Task<BaseResponse<IEnumerable<GetAddressesQueryResponse>>> Handle(GetAddressesQueryRequest request, CancellationToken cancellationToken)
        {
            Expression<Func<Domain.Entities.Address, bool>>? predicate = default;
            if (!string.IsNullOrWhiteSpace(request.SearchWord))
            {
                _ = request.SearchIn switch
                {
                    AddressSearchInType.AddressLine => predicate = address => address.AddressLine.Contains(request.SearchWord),
                    AddressSearchInType.District => predicate = address => address.District.Contains(request.SearchWord),
                    AddressSearchInType.City => predicate = address => address.City.Contains(request.SearchWord),
                    AddressSearchInType.PostalCode => predicate = address => address.PostalCode.Contains(request.SearchWord),
                    _ => predicate = address => address.Name.Contains(request.SearchWord)
                };
            }

            Func<IQueryable<Domain.Entities.Address>, IOrderedQueryable<Domain.Entities.Address>>? orderBy = default;
            if (request.OrderBy != null || request.IsReversed)
            {
                _ = request.OrderBy switch
                {
                    AddressOrderByType.CreatedOn => orderBy = request.IsReversed ? query => query.OrderByDescending(address => address.CreatedOn) : query => query.OrderBy(address => address.CreatedOn),
                    AddressOrderByType.ModifiedOn => orderBy = request.IsReversed ? query => query.OrderByDescending(address => address.ModifiedOn) : query => query.OrderBy(address => address.ModifiedOn),
                    AddressOrderByType.Name => orderBy = request.IsReversed ? query => query.OrderByDescending(address => address.Name) : query => query.OrderBy(address => address.Name),
                    AddressOrderByType.AddressLine => orderBy = request.IsReversed ? query => query.OrderByDescending(address => address.AddressLine) : query => query.OrderBy(address => address.AddressLine),
                    AddressOrderByType.District => orderBy = request.IsReversed ? query => query.OrderByDescending(address => address.District) : query => query.OrderBy(address => address.District),
                    AddressOrderByType.City => orderBy = request.IsReversed ? query => query.OrderByDescending(address => address.City) : query => query.OrderBy(address => address.City),
                    AddressOrderByType.PostalCode => orderBy = request.IsReversed ? query => query.OrderByDescending(address => address.PostalCode) : query => query.OrderBy(address => address.PostalCode),
                    _ => orderBy = request.IsReversed ? query => query.OrderByDescending(address => address.CreatedOn) : query => query.OrderBy(address => address.CreatedOn)
                };
            }

            var addresses = await _addressReadRepository.GetAsync(request.PageNumber, request.PageSize, orderBy, predicate, request.Includes, cancellationToken);

            if (addresses == null)
                return BaseResponse<IEnumerable<GetAddressesQueryResponse>>.Fail("Failed to retrieve Addresses.", 500);

            int? count = default;
            if (request.NeedCount)
                count = await _addressReadRepository.CountAsync(predicate, cancellationToken);

            var sorting = new SortedListResponse() { PageNumber = request.PageNumber, PageSize = request.PageSize, IsReversed = request.IsReversed, NeedCount = request.NeedCount, Count = count, SearchWord = request.SearchWord };

            return BaseResponse<IEnumerable<GetAddressesQueryResponse>>.Success(_mapper.Map<IEnumerable<GetAddressesQueryResponse>>(addresses), 200, sorting);
        }
    }
}
