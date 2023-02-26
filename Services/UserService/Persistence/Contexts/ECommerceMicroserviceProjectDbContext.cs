using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UserService.Domain.Entities;

namespace UserService.Persistence.Contexts
{
    public class ECommerceMicroserviceProjectDbContext : DbContext
    {
        public ECommerceMicroserviceProjectDbContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                if (data.State == EntityState.Added)
                    data.Entity.CreatedOn = DateTime.UtcNow;
                else if (data.State == EntityState.Modified)
                    data.Entity.ModifiedOn = DateTime.UtcNow;
            }
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                if (data.State == EntityState.Added)
                    data.Entity.CreatedOn = DateTime.UtcNow;
                else if (data.State == EntityState.Modified)
                    data.Entity.ModifiedOn = DateTime.UtcNow;
            }
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
