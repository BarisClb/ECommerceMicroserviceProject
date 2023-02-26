using UserService.Domain.Entities;

namespace UserService.Application.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    { }
}
