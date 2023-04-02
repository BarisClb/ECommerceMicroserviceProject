using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Persistence.Contexts;

namespace UserService.Persistence.Repositories
{
    public class AddressWriteRepository : BaseWriteRepository<Address>, IAddressWriteRepository
    {
        public AddressWriteRepository(ECommerceMicroserviceProjectDbContext context) : base(context)
        { }
    }
}
