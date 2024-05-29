using Domain.Abstractions;

namespace Infrastructure.Persistence.EntityFramework
{
    internal class EfUnitOfWork(ApplicationDbContext context) : IUnitOfWork
    {
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
