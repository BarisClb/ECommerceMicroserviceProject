using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Persistence.Contexts;

namespace UserService.Persistence.Repositories
{
    public class AddressReadRepository : BaseReadRepository<Address>, IAddressReadRepository
    {
        public AddressReadRepository(ECommerceMicroserviceProjectDbContext context) : base(context)
        { }
    }
}
