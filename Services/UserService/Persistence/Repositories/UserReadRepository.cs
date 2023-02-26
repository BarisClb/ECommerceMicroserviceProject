using UserService.Application.Interfaces;
using UserService.Domain.Entities;
using UserService.Persistence.Contexts;

namespace UserService.Persistence.Repositories
{
    public class UserReadRepository : BaseReadRepository<User>, IUserReadRepository
    {
        public UserReadRepository(ECommerceMicroserviceProjectDbContext context) : base(context)
        { }
    }
}
