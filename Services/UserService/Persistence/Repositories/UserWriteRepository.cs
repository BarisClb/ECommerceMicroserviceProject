using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Persistence.Contexts;

namespace UserService.Persistence.Repositories
{
    public class UserWriteRepository : BaseWriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(ECommerceMicroserviceProjectDbContext context) : base(context)
        { }
    }
}
